using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace RBA.Domain.Entities {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "V_User_Access", DisableSyncStructure = true)]
	public partial class V_UserAccess {

		[JsonProperty, Column(Name = "action_id")]
		public int Action_Id { get; set; }

		[JsonProperty, Column(Name = "app_description", DbType = "varchar(100)")]
		public string? App_Description { get; set; }

		[JsonProperty, Column(Name = "application_cd", DbType = "varchar(3)", IsNullable = false)]
		public string? Application_Cd { get; set; }

		[JsonProperty, Column(Name = "approval_status", DbType = "varchar(50)")]
		public string? Approval_Status { get; set; }

		[JsonProperty, Column(Name = "is_active")]
		public bool? Is_Active { get; set; }

		[JsonProperty, Column(Name = "name", DbType = "varchar(100)")]
		public string? Name { get; set; }

		[JsonProperty, Column(Name = "plant_cd", DbType = "varchar(10)", IsNullable = false)]
		public string? Plant_Cd { get; set; }

		[JsonProperty, Column(Name = "role_description", DbType = "varchar(100)")]
		public string? Role_Description { get; set; }

		[JsonProperty, Column(Name = "role_id")]
		public int Role_Id { get; set; }

		[JsonProperty, Column(Name = "role_name", DbType = "varchar(100)", IsNullable = false)]
		public string? Role_Name { get; set; }

		[JsonProperty, Column(Name = "user_cd", DbType = "varchar(50)", IsNullable = false)]
		public string? User_Cd { get; set; }

	}

}
