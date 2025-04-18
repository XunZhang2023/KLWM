using FreeSql.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KLWM.DataCore.Context
{
    public class UserInfoConText : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void PropChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string uid;
        /// <summary>
        /// 工号
        /// </summary>
        public string Uid
        {
            get => uid; set
            {
                if (uid != value)
                {
                    uid = value;
                    PropChanged();
                }
            }
        }

        private string uname;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Uname
        {
            get => uname; set
            {
                if (uname != value)
                {
                    uname = value;
                    PropChanged();
                }
            }
        }

        private string ustation;
        /// <summary>
        /// 岗位
        /// </summary>
        public string Ustation
        {
            get => ustation; set
            {
                if (ustation != value)
                {
                    ustation = value;
                    PropChanged();
                }
            }
        }

        private byte[] uphoto;
        /// <summary>
        /// 照片
        /// </summary>
        public byte[] Uphoto
        {
            get => uphoto; set
            {
                if (uphoto != value)
                {
                    uphoto = value;
                    PropChanged();
                }
            }
        }

    }
}
