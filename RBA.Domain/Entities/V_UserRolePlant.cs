using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "v_user_role_role_plant", DisableSyncStructure = true)]
public partial class V_UserRolePlant
{

  [JsonProperty, Column(Name = "application_cd", DbType = "varchar(3)", IsNullable = false)]
  public string? Application_Cd { get; set; }

  [JsonProperty, Column(Name = "approval_status", DbType = "varchar(50)")]
  public string? Approval_Status { get; set; }

  [JsonProperty, Column(Name = "approved_by", DbType = "varchar(50)")]
  public string? Approved_By { get; set; }

  [JsonProperty, Column(Name = "approved_date")]
  public DateTime? Approved_Date { get; set; }

  [JsonProperty, Column(Name = "approver_reason", DbType = "varchar(100)")]
  public string? Approver_Reason { get; set; }

  [JsonProperty, Column(Name = "can_assign")]
  public bool? Can_Assign { get; set; }

  [JsonProperty, Column(Name = "can_change_actions")]
  public bool? Can_Change_Actions { get; set; }

  [JsonProperty, Column(Name = "created_date")]
  public DateTime Created_Date { get; set; }

  [JsonProperty, Column(Name = "description", DbType = "varchar(100)")]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_Active { get; set; }

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "plant_cd", DbType = "varchar(10)", IsNullable = false)]
  public string? Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "request_by", DbType = "varchar(50)", IsNullable = false)]
  public string? Request_By { get; set; }

  [JsonProperty, Column(Name = "request_justification", DbType = "varchar(100)", IsNullable = false)]
  public string? Request_Justification { get; set; }

  [JsonProperty, Column(Name = "role_id")]
  public int Role_Id { get; set; }

  [JsonProperty, Column(Name = "role_name", DbType = "varchar(100)", IsNullable = false)]
  public string? Role_Name { get; set; }

  [JsonProperty, Column(Name = "user_cd", DbType = "varchar(50)", IsNullable = false)]
  public string? User_Cd { get; set; }

  [JsonProperty, Column(Name = "user_role_id")]
  public int User_Role_Id { get; set; }

}
