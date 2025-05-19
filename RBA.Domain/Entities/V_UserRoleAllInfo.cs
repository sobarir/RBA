using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.v_user_role_all_info", DisableSyncStructure = true)]
public partial class V_UserRoleAllInfo
{

  [JsonProperty, Column(Name = "app_desc", StringLength = 150)]
  public string? App_desc { get; set; }

  [JsonProperty, Column(Name = "application_cd", StringLength = 3)]
  public string? Application_cd { get; set; }

  [JsonProperty, Column(Name = "application_owner", StringLength = 50)]
  public string? Application_owner { get; set; }

  [JsonProperty, Column(Name = "approval_status", StringLength = 50)]
  public string? Approval_status { get; set; }

  [JsonProperty, Column(Name = "approved_by", StringLength = 50)]
  public string? Approved_by { get; set; }

  [JsonProperty, Column(Name = "approved_date", DbType = "timestamptz")]
  public DateTime? Approved_date { get; set; }

  [JsonProperty, Column(Name = "approver_email", StringLength = 100)]
  public string? Approver_email { get; set; }

  [JsonProperty, Column(Name = "approver_first_name", StringLength = 50)]
  public string? Approver_first_name { get; set; }

  [JsonProperty, Column(Name = "approver_last_name", StringLength = 50)]
  public string? Approver_last_name { get; set; }

  [JsonProperty, Column(Name = "approver_reason", StringLength = 100)]
  public string? Approver_reason { get; set; }

  [JsonProperty, Column(Name = "can_assign")]
  public bool? Can_assign { get; set; }

  [JsonProperty, Column(Name = "can_change_actions")]
  public bool? Can_change_actions { get; set; }

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz")]
  public DateTime? Created_date { get; set; }

  [JsonProperty, Column(Name = "description")]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "expr1", StringLength = 50)]
  public string? Expr1 { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool? Is_active { get; set; }

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz")]
  public DateTime? Last_edit_date { get; set; }

  [JsonProperty, Column(Name = "plant_cd", StringLength = 10)]
  public string? Plant_cd { get; set; }

  [JsonProperty, Column(Name = "request_by", StringLength = 50)]
  public string? Request_by { get; set; }

  [JsonProperty, Column(Name = "request_justification", StringLength = 100)]
  public string? Request_justification { get; set; }

  [JsonProperty, Column(Name = "requester_email", StringLength = 100)]
  public string? Requester_email { get; set; }

  [JsonProperty, Column(Name = "requester_first_name", StringLength = 50)]
  public string? Requester_first_name { get; set; }

  [JsonProperty, Column(Name = "requester_last_name", StringLength = 50)]
  public string? Requester_last_name { get; set; }

  [JsonProperty, Column(Name = "role_id")]
  public int? Role_id { get; set; }

  [JsonProperty, Column(Name = "role_name", StringLength = 100)]
  public string? Role_name { get; set; }

  [JsonProperty, Column(Name = "user_cd", StringLength = 50)]
  public string? User_cd { get; set; }

  [JsonProperty, Column(Name = "user_role_id")]
  public int? User_role_id { get; set; }

}
