using KLWM.DataCore.Context;
using NetSDKCS;
using ProcessControlSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TrainLoadingRefactor.DataCore.DataModel;

namespace KLWM.Auxiliary
{
    public static class StaticDelegates
    {
        public static UserInfoConText wUserinfo = new UserInfoConText();

        public static void InitGeneralControl()
        {
            wUserinfo.PropertyChanged += WUserinfo_PropertyChanged;
        }
        public delegate void RspBarcode(string cPort, string barcode);
        /// <summary>
        /// 扫描触发
        /// </summary>
        public static event RspBarcode OnRspBarcode;
        /// <summary>
        /// 摄像头识别人员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void WUserinfo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UserInfoStruct userContext = new UserInfoStruct()
            {
                Uname = wUserinfo.Uname,
                Uid = wUserinfo.Uid,
                Ustation = wUserinfo.Ustation,
                Uphoto = wUserinfo.Uphoto
            };
            OnRspUserInfoChange?.Invoke(userContext);
        }
        public delegate void RspKanbanDataInChange();
        /// <summary>
        /// 看板入库
        /// </summary>
        public static event RspKanbanDataInChange OnRspKanbanDataInChange;
        public delegate void RspKanbanDataOutChange();
        /// <summary>
        /// 看板出库
        /// </summary>
        public static event RspKanbanDataOutChange OnRspKanbanDataOutChange;

        public delegate void RspInOrOutCountChange(Double inOrOutCount);
        /// <summary>
        /// 出入库数量输入
        /// </summary>
        public static event RspInOrOutCountChange OnRspInOrOutCountChange;

        public delegate void RspUserInfoChange(UserInfoStruct userContext);
        /// <summary>
        /// 人员信息变动
        /// </summary>
        public static event RspUserInfoChange OnRspUserInfoChange;

        public static void SetInOrOutCount(Double inOrOutCount)
        {
            OnRspInOrOutCountChange?.Invoke(inOrOutCount);
        }
        public static void KanbanDataInChange()
        {
            OnRspKanbanDataInChange?.Invoke();
        }
        public static void KanbanDataOutChange()
        {
            OnRspKanbanDataOutChange?.Invoke();
        }
        public static void OnPeopleFaceChange(NET_A_DEV_EVENT_SECURITYGATE_PERSONALARM_INFO info)
        {
            UserInfoStruct userInfoStruct = new UserInfoStruct();
            var candidatesInfo = info.stuCandidates.ToList().OrderByDescending(p => p.nSimilarity).ToArray();
            NET_SECURITYGATE_CANDIDATE maxSimilarityPersonInfo = candidatesInfo[0];

            userInfoStruct.Uid = maxSimilarityPersonInfo.stuPerson.szGroupID;
            userInfoStruct.Uname = maxSimilarityPersonInfo.stuPerson.szPersonName;

            OnRspUserInfoChange?.Invoke(userInfoStruct);
        }

    }
}
