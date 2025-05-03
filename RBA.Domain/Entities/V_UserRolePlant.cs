using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.v_user_role_role_plant", DisableSyncStructure = true)]
public partial class V_UserRolePlant : IEntity
{

  [JsonProperty, Column(Name = "user_role_id")]
  public int User_Role_Id { get; set; }

  [JsonProperty, Column(Name = "user_cd", StringLength = 50, IsNullable = false)]
  public required string User_Cd { get; set; }

  [JsonProperty, Column(Name = "role_id")]
  public required int Role_Id { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_active { get; set; } = false;

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "can_assign")]
  public bool? Can_Assign { get; set; }

  [JsonProperty, Column(Name = "can_change_actions")]
  public bool? Can_Change_Actions { get; set; }

  [JsonProperty, Column(Name = "request_by", StringLength = 50)]
  public string? Request_By { get; set; }

  [JsonProperty, Column(Name = "request_justification", StringLength = 100)]
  public string? Request_Justification { get; set; }

  [JsonProperty, Column(Name = "approved_by", StringLength = 50)]
  public string? Approved_By { get; set; }

  [JsonProperty, Column(Name = "approver_reason", StringLength = 100)]
  public string? Approver_Reason { get; set; }

  [JsonProperty, Column(Name = "approval_status", StringLength = 50)]
  public string? Approval_Status { get; set; }

  [JsonProperty, Column(Name = "approved_date", DbType = "timestamptz")]
  public DateTime? Approved_Date { get; set; }

  [JsonProperty, Column(Name = "role_name", StringLength = 100, IsNullable = false)]
  public required string Role_Name { get; set; }

  [JsonProperty, Column(Name = "plant_cd", StringLength = 10)]
  public string? Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "application_cd", StringLength = 3, IsNullable = false)]
  public required string Application_Cd { get; set; }

  [JsonProperty, Column(Name = "description", StringLength = 150)]
  public string? Description { get; set; }

}
