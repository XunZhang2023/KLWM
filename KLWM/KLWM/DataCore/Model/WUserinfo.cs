using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace TrainLoadingRefactor.DataCore.DataModel {

	/// <summary>
	/// 员工信息
	/// </summary>
	[JsonObject(MemberSerialization.OptIn), Table(Name = "w_userinfo", DisableSyncStructure = true)]
	public partial class WUserinfo {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		[JsonProperty, Column(Name = "CTime", DbType = "datetime")]
		public DateTime? CTime { get; set; }

		/// <summary>
		/// 工号
		/// </summary>
		[JsonProperty, Column(Name = "UId", StringLength = 50)]
		public string UId { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		[JsonProperty, Column(Name = "UName", StringLength = 50)]
		public string UName { get; set; }

		/// <summary>
		/// 照片
		/// </summary>
		[JsonProperty, Column(Name = "UPhoto", DbType = "mediumblob")]
		public byte[] UPhoto { get; set; }

		/// <summary>
		/// 岗位
		/// </summary>
		[JsonProperty, Column(Name = "UStation", StringLength = 50)]
		public string UStation { get; set; }

		[JsonProperty, Column(Name = "ValidFlag")]
		public int? ValidFlag { get; set; }

	}

}
