using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.user_role", DisableSyncStructure = true)]
public partial class UserRole : IEntity
{

  [JsonProperty, Column(Name = "role_id", IsPrimary = true)]
  public required int Role_Id { get; set; }

  [JsonProperty, Column(Name = "user_cd", DbType = "varchar(50)", IsPrimary = true, IsNullable = false)]
  public required string User_Cd { get; set; }

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
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "email_notification", DbType = "varchar(50)", IsNullable = false)]
  public string Email_Notification { get; set; } = "not send";

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_Active { get; set; } = true;

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "request_by", DbType = "varchar(50)", IsNullable = false)]
  public string? Request_By { get; set; }

  [JsonProperty, Column(Name = "request_justification", DbType = "varchar(100)", IsNullable = false)]
  public string? Request_Justification { get; set; }

  [JsonProperty, Column(Name = "user_role_id", IsIdentity = true)]
  public int User_Role_Id { get; set; }

  [JsonProperty, Column(Name = "revoke_justification", DbType = "varchar(100)", IsNullable = true)]
  public string? Revoke_Justification { get; set; }

  [JsonProperty, Column(Name = "revoke_by", DbType = "varchar(50)", IsNullable = true)]
  public string? Revoke_By { get; set; }

  [JsonProperty, Column(Name = "revoke_date", IsNullable = true)]
  public DateTime? Revoke_Date { get; set; }

  [JsonProperty, Column(Name = "revoke_req_by", DbType = "varchar(50)", IsNullable = true)]
  public string? Revoke_Req_By { get; set; }

  [JsonProperty, Column(Name = "revoke_req_date", IsNullable = true)]
  public DateTime? Revoke_Req_Date { get; set; }

}
