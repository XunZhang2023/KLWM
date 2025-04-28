using DevExpress.XtraEditors.Filtering;
using NetSDKCS;
using NPOI.OpenXmlFormats.Vml;
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
using TrainLoadingRefactor.DataCore.DataModel;

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

        private static string _ip="192.168.1.109";
        private static ushort _port=37777;
        private static string _username="admin";
        private static string _password="Pass@123";

        public static event Action DeviceDisconnected;
        private const int m_WaitTime = 3000;
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
        public static bool InitSDK()
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
        public static void Realplay(IntPtr handle)
        {
            if (m_PlayID == IntPtr.Zero)
            {
                m_PlayID = NETClient.RealPlay(m_LoginID,0,handle);
                if (IntPtr.Zero == m_PlayID)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                bool res = NETClient.RenderPrivateData(m_PlayID, true);
                if (!res)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
            }
            else
            {
                bool ret = NETClient.RenderPrivateData(m_PlayID, false);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                ret = NETClient.StopRealPlay(m_PlayID);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                    return;
                }
                m_PlayID = IntPtr.Zero;
            }
        }
        /// <summary>
        /// 订阅事件
        /// </summary>
        public static void AttachEvent()
        {
            if (IntPtr.Zero == m_AnalyzerID)
            {
                m_AnalyzerID = NETClient.RealLoadPicture(m_LoginID, 0, (uint)EM_EVENT_IVS_TYPE.ALL, true, m_AnalyzerDataCallBack, IntPtr.Zero, IntPtr.Zero);
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
                    //人脸识别
                    case (uint)EM_EVENT_IVS_TYPE.FACERECOGNITION:
                        {
                            NET_DEV_EVENT_FACERECOGNITION_INFO info = (NET_DEV_EVENT_FACERECOGNITION_INFO)Marshal.PtrToStructure(pEventInfo, typeof(NET_DEV_EVENT_FACERECOGNITION_INFO));
                            if (IntPtr.Zero != pBuffer && dwBufSize > 0)
                            {
                                if (info.bGlobalScenePic)
                                {
                                    if (info.stuGlobalScenePicInfo.dwFileLenth > 0)
                                    {
                                        byte[] globalScenePicInfo = new byte[info.stuGlobalScenePicInfo.dwFileLenth];
                                        Marshal.Copy(IntPtr.Add(pBuffer, (int)info.stuGlobalScenePicInfo.dwOffSet), globalScenePicInfo, 0, (int)info.stuGlobalScenePicInfo.dwFileLenth);
                                        using (MemoryStream stream = new MemoryStream(globalScenePicInfo))
                                        {
                                            try // add try catch for catch exception when the stream is not image format,and the stream is from device.
                                            {
                                                StaticDelegates.OnPeopleFaceChange(info);///20250417
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //clear
                                    StaticDelegates.OnPeopleFaceChange(info);///20250417
                                }
                                #region 临时屏蔽
                                //if (info.stuObject.stPicInfo.dwFileLenth > 0)
                                //{
                                //    byte[] personFaceInfo = new byte[info.stuObject.stPicInfo.dwFileLenth];
                                //    Marshal.Copy(IntPtr.Add(pBuffer, (int)info.stuObject.stPicInfo.dwOffSet), personFaceInfo, 0, (int)info.stuObject.stPicInfo.dwFileLenth);
                                //    using (MemoryStream stream = new MemoryStream(personFaceInfo))
                                //    {
                                //        try // add try catch for catch exception when the stream is not image format,and the stream is from device.
                                //        {
                                //            StaticDelegates.OnPeopleFaceChange(info);///20250417
                                //        }
                                //        catch (Exception ex)
                                //        {
                                //            Console.WriteLine(ex);
                                //        }
                                //    }
                                //}
                                //if (info.nCandidateNum > 0)
                                //{
                                //    var candidatesInfo = info.stuCandidates.ToList().OrderByDescending(p => p.bySimilarity).ToArray();
                                //    NET_CANDIDATE_INFO maxSimilarityPersonInfo = candidatesInfo[0];
                                //    if (maxSimilarityPersonInfo.stPersonInfo.szFacePicInfo[0].dwFileLenth > 0)
                                //    {
                                //        byte[] candidateInfo = new byte[maxSimilarityPersonInfo.stPersonInfo.szFacePicInfo[0].dwFileLenth];
                                //        Marshal.Copy(IntPtr.Add(pBuffer, (int)maxSimilarityPersonInfo.stPersonInfo.szFacePicInfo[0].dwOffSet), candidateInfo, 0, (int)maxSimilarityPersonInfo.stPersonInfo.szFacePicInfo[0].dwFileLenth);
                                //        using (MemoryStream stream = new MemoryStream(candidateInfo))
                                //        {
                                //            try // add try catch for catch exception when the stream is not image format,and the stream is from device.
                                //            {
                                //                StaticDelegates.OnPeopleFaceChange(info);///20250417
                                //            }
                                //            catch (Exception ex)
                                //            {
                                //                Console.WriteLine(ex);
                                //            }
                                //        }
                                //        string groupID = Marshal.PtrToStringAnsi(maxSimilarityPersonInfo.stPersonInfo.pszGroupID);
                                //        string groupName = Marshal.PtrToStringAnsi(maxSimilarityPersonInfo.stPersonInfo.pszGroupName);
                                //    }
                                //}
                                //else
                                //{

                                //    StaticDelegates.OnPeopleFaceChange(info);///20250417
                                //}
                                #endregion
                            }
                        }
                        break;
                    //人脸检测
                    case (uint)EM_EVENT_IVS_TYPE.FACEDETECT:
                        {
                            NET_DEV_EVENT_FACEDETECT_INFO info = (NET_DEV_EVENT_FACEDETECT_INFO)Marshal.PtrToStructure(pEventInfo, typeof(NET_DEV_EVENT_FACEDETECT_INFO));
                            if (m_GroupID != info.stuObject.nRelativeID)
                            {
                                m_GroupID = info.stuObject.nObjectID;
                                byte[] globalScenePicInfo = new byte[dwBufSize];
                                Marshal.Copy(pBuffer, globalScenePicInfo, 0, (int)dwBufSize);
                                using (MemoryStream stream = new MemoryStream(globalScenePicInfo))
                                {
                                    try // add try catch for catch exception when the stream is not image format,and the stream is from device.
                                    {
                                        //Image globalSceneImage = Image.FromStream(stream);
                                        //pictureBox_image.Image = globalSceneImage;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                            }
                            else
                            {
                                byte[] personFaceInfo = new byte[dwBufSize];
                                Marshal.Copy(pBuffer, personFaceInfo, 0, (int)dwBufSize);
                                using (MemoryStream stream = new MemoryStream(personFaceInfo))
                                {
                                    try // add try catch for catch exception when the stream is not image format,and the stream is from device.
                                    {
                                        //Image faceImage = Image.FromStream(stream);
                                        //pictureBox_faceimage.Image = faceImage;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                            }
                        }
                        break;
                    //通道报警
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
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
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
        public static void AddPersonInfo(WUserinfo personInfo)
        {
            if (IntPtr.Zero == m_LoginID)
            {
                MessageBox.Show("Device is offline(设备已离线)!");
                return;
            }
            bool ret = false;

            NET_IN_OPERATE_FACERECONGNITIONDB stuInParam = new NET_IN_OPERATE_FACERECONGNITIONDB();
            try
            {
                stuInParam.dwSize = (uint)Marshal.SizeOf(typeof(NET_IN_OPERATE_FACERECONGNITIONDB));
                stuInParam.emOperateType = EM_OPERATE_FACERECONGNITIONDB_TYPE.ADD;//operate
                stuInParam.stPersonInfo.szPersonNameEx = personInfo.UName.Trim();
                stuInParam.stPersonInfo.szID = personInfo.UId.Trim();
                stuInParam.stPersonInfo.bySex = (byte)(1);
                stuInParam.stPersonInfo.pszGroupID = Marshal.StringToHGlobalAnsi(personInfo.UStation);
                stuInParam.stPersonInfo.bGroupIdLen = (byte)personInfo.UStation.Length;
                stuInParam.stPersonInfo.pszGroupName = Marshal.StringToHGlobalAnsi(personInfo.UStation);
                stuInParam.stPersonInfo.byIDType = (byte)(1);
                stuInParam.stPersonInfo.wFacePicNum = 1;
                byte[] data = personInfo.UPhoto;
                stuInParam.stPersonInfo.szFacePicInfo = new NET_PIC_INFO[48];
                for (int i = 0; i < 48; i++)
                {
                    stuInParam.stPersonInfo.szFacePicInfo[i] = new NET_PIC_INFO();
                }
                stuInParam.stPersonInfo.szFacePicInfo[0].dwFileLenth = (uint)data.Length;
                stuInParam.stPersonInfo.szFacePicInfo[0].dwOffSet = 0;
                stuInParam.nBufferLen = data.Length;
                if (0 == stuInParam.nBufferLen)
                {
                    stuInParam.pBuffer = IntPtr.Zero;
                }
                else
                {
                    stuInParam.pBuffer = Marshal.AllocHGlobal(stuInParam.nBufferLen);
                    Marshal.Copy(data, 0, stuInParam.pBuffer, stuInParam.nBufferLen);
                }


                NET_OUT_OPERATE_FACERECONGNITIONDB stuOutParam = new NET_OUT_OPERATE_FACERECONGNITIONDB();
                stuOutParam.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_OPERATE_FACERECONGNITIONDB));

                ret = NETClient.OperateFaceRecognitionDB(m_LoginID, ref stuInParam, ref stuOutParam, m_WaitTime);
                if (!ret)
                {
                    MessageBox.Show(NETClient.GetLastError());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(stuInParam.stPersonInfo.pszGroupID);
                Marshal.FreeHGlobal(stuInParam.stPersonInfo.pszGroupName);
                Marshal.FreeHGlobal(stuInParam.pBuffer);
            }
        }

    }
}
