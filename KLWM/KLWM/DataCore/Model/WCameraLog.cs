using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace TrainLoadingRefactor.DataCore.DataModel {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "w_camera_log", DisableSyncStructure = true)]
	public partial class WCameraLog {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public int Id { get; set; }

		/// <summary>
		/// 进入图片
		/// </summary>
		[JsonProperty, Column(Name = "InPtoto", DbType = "mediumblob")]
		public byte[] InPtoto { get; set; }

		/// <summary>
		/// 进入时间
		/// </summary>
		[JsonProperty, Column(Name = "InTime", DbType = "datetime")]
		public DateTime? InTime { get; set; }

		/// <summary>
		/// 是否出库
		/// </summary>
		[JsonProperty, Column(Name = "IsOutbound")]
		public int? IsOutbound { get; set; }

		/// <summary>
		/// 出库内容
		/// </summary>
		[JsonProperty, Column(Name = "OutboundInfo", StringLength = 50)]
		public string OutboundInfo { get; set; }

		/// <summary>
		/// 出去图片
		/// </summary>
		[JsonProperty, Column(Name = "OutPhoto", DbType = "mediumblob")]
		public byte[] OutPhoto { get; set; }

		/// <summary>
		/// 出去时间
		/// </summary>
		[JsonProperty, Column(Name = "OutTime", DbType = "datetime")]
		public DateTime? OutTime { get; set; }

		/// <summary>
		/// 员工ID
		/// </summary>
		[JsonProperty, Column(Name = "UId", StringLength = 50)]
		public string UId { get; set; }

		/// <summary>
		/// 员工姓名
		/// </summary>
		[JsonProperty, Column(Name = "UName", StringLength = 50)]
		public string UName { get; set; }

		/// <summary>
		/// 员工岗位
		/// </summary>
		[JsonProperty, Column(Name = "UStation", StringLength = 50)]
		public string UStation { get; set; }

		/// <summary>
		/// 是否有效
		/// </summary>
		[JsonProperty, Column(Name = "ValidFlag")]
		public int? ValidFlag { get; set; }

	}

}
