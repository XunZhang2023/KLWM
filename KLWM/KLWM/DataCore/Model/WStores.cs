using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;
using System.ComponentModel;

namespace TrainLoadingRefactor.DataCore.DataModel {

	/// <summary>
	/// 库存表
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "w_stores", DisableSyncStructure = true)]
	public partial class WStores {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [JsonProperty, Column(Name = "CTime", DbType = "datetime")]
        [Description("时间")]
        public DateTime? CTime { get; set; }

		/// <summary>
		/// 数量
		/// </summary>
		[JsonProperty, Column(Name = "PCount")]
        [Description("数量")]
        public double? PCount { get; set; }

		/// <summary>
		/// 厂商
		/// </summary>
		[JsonProperty, Column(Name = "PManufacturer", StringLength = 50)]
        [Description("厂商")]
        public string PManufacturer { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[JsonProperty, Column(Name = "PName", StringLength = 50)]
        [Description("名称")]
        public string PName { get; set; }

		/// <summary>
		/// 编号
		/// </summary>
		[JsonProperty, Column(Name = "PNo", StringLength = 50)]
        [Description("编号")]
        public string PNo { get; set; }

		/// <summary>
		/// 规格
		/// </summary>
		[JsonProperty, Column(Name = "PSize", StringLength = 50)]
        [Description("规格")]
        public string PSize { get; set; }

		/// <summary>
		/// 类型
		/// </summary>
		[JsonProperty, Column(Name = "PType", StringLength = 20)]
        [Description("类别")]
        public string PType { get; set; }

		/// <summary>
		/// 单位
		/// </summary>
		[JsonProperty, Column(Name = "PUnit", StringLength = 50)]
        [Description("单位")]
        public string PUnit { get; set; }

		/// <summary>
		/// 是否有效
		/// </summary>
		[JsonProperty, Column(Name = "ValidFlag")]
        [Description("是否有效")]
        public int? ValidFlag { get; set; } = 1;

	}

}
