using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace RBA.Domain.Entities {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "V_User_Action", DisableSyncStructure = true)]
	public partial class V_UserAction {

		[JsonProperty, Column(Name = "action_id")]
		public int Action_Id { get; set; }

		[JsonProperty, Column(Name = "name", DbType = "varchar(100)")]
		public string? Name { get; set; }

    [JsonProperty, Column(Name = "user_cd", DbType = "varchar(50)", IsNullable = false)]
    public string? User_Cd { get; set; }

  }

}
