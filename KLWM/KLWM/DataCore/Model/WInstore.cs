using System;
using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace TrainLoadingRefactor.DataCore.DataModel
{

    /// <summary>
    /// 录入库
    /// </summary>
    [JsonObject(MemberSerialization.OptIn), Table(Name = "w_instore", DisableSyncStructure = true)]
	public partial class WInstore {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[JsonProperty, Column(StringLength = 50)]
		public string Comment { get; set; }

		/// <summary>
		/// 时间
		/// </summary>
		[JsonProperty, Column(Name = "CTime", DbType = "datetime")]
		public DateTime? CTime { get; set; }

		/// <summary>
		/// 入库量
		/// </summary>
		[JsonProperty, Column(Name = "InCount")]
		public double? InCount { get; set; }

		/// <summary>
		/// 厂商
		/// </summary>
		[JsonProperty, Column(Name = "PManufacturer", StringLength = 50)]
		public string PManufacturer { get; set; }

		/// <summary>
		/// 产品名称
		/// </summary>
		[JsonProperty, Column(Name = "PName", StringLength = 20)]
		public string PName { get; set; }

		/// <summary>
		/// 编号
		/// </summary>
		[JsonProperty, Column(Name = "PNo", StringLength = 20)]
		public string PNo { get; set; }

		/// <summary>
		/// 参数
		/// </summary>
		[JsonProperty, Column(Name = "PSize", StringLength = 50)]
		public string PSize { get; set; }

		/// <summary>
		/// 产品类型
		/// </summary>
		[JsonProperty, Column(Name = "PType", StringLength = 20)]
		public string PType { get; set; }

		/// <summary>
		/// 单位
		/// </summary>
		[JsonProperty, Column(Name = "PUnit", StringLength = 20)]
		public string PUnit { get; set; }

		/// <summary>
		/// 是否有效
		/// </summary>
		[JsonProperty, Column(Name = "ValidFlag")]
		public int ValidFlag { get; set; } = 1;

	}

}
