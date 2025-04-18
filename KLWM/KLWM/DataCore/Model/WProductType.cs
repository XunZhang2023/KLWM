using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace TrainLoadingRefactor.DataCore.DataModel {

	/// <summary>
	/// 类别
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "w_product_type", DisableSyncStructure = true)]
	public partial class WProductType {

		[JsonProperty, Column(DbType = "int(4) unsigned zerofill", IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		[JsonProperty, Column(Name = "CTime", DbType = "datetime")]
		public DateTime? CTime { get; set; }

		/// <summary>
		/// 厂家
		/// </summary>
		[JsonProperty, Column(Name = "PManufacturer", StringLength = 50)]
		public string PManufacturer { get; set; }

		/// <summary>
		/// 型号
		/// </summary>
		[JsonProperty, Column(Name = "PSize", StringLength = 50)]
		public string PSize { get; set; }

		/// <summary>
		/// 产品类型
		/// </summary>
		[JsonProperty, Column(Name = "PType", StringLength = 50)]
		public string PType { get; set; }

		[JsonProperty, Column(Name = "ValidFlag")]
		public int? ValidFlag { get; set; }

	}

}
