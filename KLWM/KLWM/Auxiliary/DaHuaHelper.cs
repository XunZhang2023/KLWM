using NetSDKCS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace KLWM.Auxiliary
{
    public class DaHuaHelper
    {
        private static fAnalyzerDataCallBack m_AnalyzerDataCallBack;
        private static fDisConnectCallBack m_DisConnectCallBack;
        // 登录句柄
        private static IntPtr m_lLoginHandle = IntPtr.Zero;
        // 报警布防句柄
        private static IntPtr m_lAlarmHandle = IntPtr.Zero;
        // 截图保存路径
        private static string m_savePath = "C:\\DahuaSnapshots\\";

        private static NET_DEVICEINFO_Ex m_DevInfo = new NET_DEVICEINFO_Ex();
        private static IntPtr m_LoginID = IntPtr.Zero;
        private static IntPtr m_PlayID = IntPtr.Zero;
        private static IntPtr m_AnalyzerID = IntPtr.Zero;
        private static int m_GroupID = 0;
        private static TextInfo m_TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

        private static string _ip;
        private static ushort _port;
        private static string _username;
        private static string _password;

        public static event Action DeviceDisconnected;
        private static void OnDeviceDisconnected()
        {
            if (null != DeviceDisconnected)
            {
                DeviceDisconnected();
            }
        }
        /// <summary>
        /// 初始化SDK
        /// </summary>
        /// <returns></returns>
        private static bool InitSDK()
        {
            m_DisConnectCallBack += DisConnectCallBack;
            m_AnalyzerDataCallBack += AnalyzerDataCallBack;
            // 初始化SDK
            bool initResult = NETClient.Init(m_DisConnectCallBack, IntPtr.Zero, null);
            if (!initResult)
            {
                string error = NETClient.GetLastError();
                Console.WriteLine($"初始化失败，错误码: {error}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 登录
        /// </summary>
        public static void Login()
        {
            if (IntPtr.Zero == m_LoginID)
            {
                m_LoginID = NETClient.LoginWithHighLevelSecurity(_ip, _port, _username, _password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DevInfo);
                if (IntPtr.Zero == m_LoginID)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
            }
            else
            {
                bool ret = NETClient.Logout(m_LoginID);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                m_PlayID = IntPtr.Zero;
                m_LoginID = IntPtr.Zero;
                m_AnalyzerID = IntPtr.Zero;
            }
        }
        /// <summary>
        /// 登出
        /// </summary>
        public static void Logout()
        {
            if (IntPtr.Zero != m_LoginID)
            {
                bool ret = NETClient.Logout(m_LoginID);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }

            }
        }
        /// <summary>
        /// 订阅事件
        /// </summary>
        public static void AttachEvent()
        {
            if (IntPtr.Zero == m_AnalyzerID)
            {
                m_AnalyzerID = NETClient.RealLoadPicture(m_LoginID, 1, (uint)EM_EVENT_IVS_TYPE.ALL, true, m_AnalyzerDataCallBack, IntPtr.Zero, IntPtr.Zero);
                if (IntPtr.Zero == m_AnalyzerID)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
            }
            else
            {
                bool ret = NETClient.StopLoadPic(m_AnalyzerID);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                m_GroupID = 0;
                m_AnalyzerID = IntPtr.Zero;
            }
        }

        /// <ummary>
        /// 断线重连
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pchDVRIP"></param>
        /// <param name="nDVRPort"></param>
        /// <param name="dwUser"></param>
        private static void DisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            MessageBox.Show(Marshal.PtrToStringAnsi(pchDVRIP) + "---Offline(离线)");
            NETClient.Logout(m_LoginID);
            m_LoginID = IntPtr.Zero;
            if (m_PlayID != IntPtr.Zero)
            {
                NETClient.RenderPrivateData(m_PlayID, false);
                NETClient.StopRealPlay(m_PlayID);
                m_PlayID = IntPtr.Zero;
            }
            if (m_AnalyzerID != IntPtr.Zero)
            {
                NETClient.StopLoadPic(m_AnalyzerID);
                m_AnalyzerID = IntPtr.Zero;
            }
            OnDeviceDisconnected();
        }

        /// <summary>
        /// 订阅事件回调
        /// </summary>
        /// <param name="lAnalyzerHandle"></param>
        /// <param name="dwEventType"></param>
        /// <param name="pEventInfo"></param>
        /// <param name="pBuffer"></param>
        /// <param name="dwBufSize"></param>
        /// <param name="dwUser"></param>
        /// <param name="nSequence"></param>
        /// <param name="reserved"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int AnalyzerDataCallBack(IntPtr lAnalyzerHandle, uint dwEventType, IntPtr pEventInfo, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser, int nSequence, IntPtr reserved)
        {
            if (m_AnalyzerID == lAnalyzerHandle)
            {
                switch (dwEventType)
                {
                    case (uint)EM_EVENT_IVS_TYPE.SECURITYGATE_PERSONALARM:
                        {
                            NET_A_DEV_EVENT_SECURITYGATE_PERSONALARM_INFO info = (NET_A_DEV_EVENT_SECURITYGATE_PERSONALARM_INFO)Marshal.PtrToStructure(pEventInfo, typeof(NET_A_DEV_EVENT_SECURITYGATE_PERSONALARM_INFO));
                            if (IntPtr.Zero != pBuffer && dwBufSize > 0)
                            {
                                if (info.stuImageInfo.nLength > 0)
                                {
                                    byte[] globalScenePicInfo = new byte[info.stuImageInfo.nLength];
                                    Marshal.Copy(IntPtr.Add(pBuffer, (int)info.stuImageInfo.nOffSet), globalScenePicInfo, 0, (int)info.stuImageInfo.nLength);
                                    using (MemoryStream stream = new MemoryStream(globalScenePicInfo))
                                    {
                                        try // add try catch for catch exception when the stream is not image format,and the stream is from device.
                                        {
                                            //Image globalSceneImage = Image.FromStream(stream);
                                            //pictureBox_image.Image = globalSceneImage;
                                            StaticDelegates.OnPeopleFaceChange(info);///20250417
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
                                }

                                if (info.stuFaceImageInfo.nLength > 0)
                                {
                                    byte[] personFaceInfo = new byte[info.stuFaceImageInfo.nLength];
                                    Marshal.Copy(IntPtr.Add(pBuffer, (int)info.stuFaceImageInfo.nOffSet), personFaceInfo, 0, (int)info.stuFaceImageInfo.nLength);
                                    using (MemoryStream stream = new MemoryStream(personFaceInfo))
                                    {
                                        try // add try catch for catch exception when the stream is not image format,and the stream is from device.
                                        {
                                            //Image faceImage = Image.FromStream(stream);
                                            //pictureBox_faceimage.Image = faceImage;

                                            StaticDelegates.OnPeopleFaceChange(info);///20250417
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
                                    //this.BeginInvoke(new Action<NET_A_DEV_EVENT_SECURITYGATE_PERSONALARM_INFO>(UpdateFaceProperty), info);

                                    StaticDelegates.OnPeopleFaceChange(info);///20250417
                                }

                                if (info.nCandidateNum > 0)
                                {
                                    var candidatesInfo = info.stuCandidates.ToList().OrderByDescending(p => p.nSimilarity).ToArray();
                                    NET_SECURITYGATE_CANDIDATE maxSimilarityPersonInfo = candidatesInfo[0];
                                    string groupID = maxSimilarityPersonInfo.stuPerson.szGroupID;
                                    string groupName = "";
                                    StaticDelegates.OnPeopleFaceChange(info);///20250417
                                    //this.BeginInvoke(new Action<NET_SECURITYGATE_CANDIDATE, string, string>(UpdateCandidateProperty), maxSimilarityPersonInfo, groupID, groupName);
                                }
                                else
                                {
                                    StaticDelegates.OnPeopleFaceChange(info);///20250417
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return 0;
        }
        private void UpdateFaceProperty(NET_A_DEV_EVENT_SECURITYGATE_PERSONALARM_INFO info)
        {
            //this.label_time.Text = info.UTC.ToShortString();
            //this.label_face_sex.Text = PraseSex(info.stuSecurityGateFaceInfo.emSex);
            //if (info.stuSecurityGateFaceInfo.nAge <= 0)
            //{
            //    this.label_age.Text = "Unknown(未知)";
            //}
            //else
            //{
            //    this.label_age.Text = info.stuSecurityGateFaceInfo.nAge.ToString();
            //}
            //this.label_eye.Text = m_TextInfo.ToTitleCase(Enum.GetName(typeof(EM_EYE_STATE_TYPE), info.stuSecurityGateFaceInfo.emEye).ToLower() + PraseEye(info.stuSecurityGateFaceInfo.emEye));
            //this.label_mouth.Text = m_TextInfo.ToTitleCase(Enum.GetName(typeof(EM_MOUTH_STATE_TYPE), info.stuSecurityGateFaceInfo.emMouth).ToLower() + PraseMouth(info.stuSecurityGateFaceInfo.emMouth));
            //this.label_mask.Text = m_TextInfo.ToTitleCase(Enum.GetName(typeof(EM_MASK_STATE_TYPE), info.stuSecurityGateFaceInfo.emMask).ToLower() + PraseMask(info.stuSecurityGateFaceInfo.emMask));
            //this.label_beard.Text = m_TextInfo.ToTitleCase(Enum.GetName(typeof(EM_BEARD_STATE_TYPE), info.stuSecurityGateFaceInfo.emBeard).ToLower() + PraseBeard(info.stuSecurityGateFaceInfo.emBeard));
            //this.label_face_quality.Text = "";
        }

    }
}
