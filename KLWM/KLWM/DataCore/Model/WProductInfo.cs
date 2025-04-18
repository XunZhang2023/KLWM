using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace TrainLoadingRefactor.DataCore.DataModel {

	/// <summary>
	/// 基础信息
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "w_product_info", DisableSyncStructure = true)]
	public partial class WProductInfo {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		[JsonProperty, Column(Name = "CTime", DbType = "datetime")]
		public DateTime? CTime { get; set; }

		/// <summary>
		/// 厂商
		/// </summary>
		[JsonProperty, Column(Name = "PManufacturer", StringLength = 50)]
		public string PManufacturer { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		[JsonProperty, Column(Name = "PName", StringLength = 50)]
		public string PName { get; set; }

		/// <summary>
		/// 编码
		/// </summary>
		[JsonProperty, Column(Name = "PNo", StringLength = 50)]
		public string PNo { get; set; }

		/// <summary>
		/// 规格
		/// </summary>
		[JsonProperty, Column(Name = "PSize", StringLength = 50)]
		public string PSize { get; set; }

		/// <summary>
		/// 类别
		/// </summary>
		[JsonProperty, Column(Name = "Ptype", StringLength = 50)]
		public string Ptype { get; set; }

        ///// <summary>
        ///// 类别编号
        ///// </summary>
        //[JsonProperty, Column(Name = "PtypeId", StringLength = 50)]
        //public string PtypeId { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [JsonProperty, Column(Name = "PUnit", StringLength = 50)]
		public string PUnit { get; set; }

		[JsonProperty, Column(Name = "ValidFlag")]
		public int? ValidFlag { get; set; }

	}

}
