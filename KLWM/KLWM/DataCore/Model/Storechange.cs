using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace TrainLoadingRefactor.DataCore.DataModel {

	/// <summary>
	/// VIEW
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "storechange", DisableSyncStructure = true)]
	public partial class Storechange {

		[JsonProperty, Column(Name = "CTime", DbType = "datetime")]
		public DateTime? CTime { get; set; }

		[JsonProperty, Column(Name = "PCount")]
		public Double? PCount { get; set; }

		[JsonProperty, Column(Name = "PManufacturer", StringLength = 50)]
		public string PManufacturer { get; set; }

		[JsonProperty, Column(Name = "PName", StringLength = 50)]
		public string PName { get; set; }

		[JsonProperty, Column(Name = "PNo", StringLength = 20)]
		public string PNo { get; set; }

		[JsonProperty, Column(Name = "PSize", StringLength = 50)]
		public string PSize { get; set; }

		[JsonProperty, Column(Name = "PType", StringLength = 20)]
		public string PType { get; set; }

		[JsonProperty, Column(Name = "PUnit", StringLength = 20)]
		public string PUnit { get; set; }

	}

}
