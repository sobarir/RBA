using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.user_role", DisableSyncStructure = true)]
public partial class UserRole : IEntity
{

  [JsonProperty, Column(Name = "role_id", IsPrimary = true)]
  public required int Role_Id { get; set; }

  [JsonProperty, Column(Name = "user_cd", StringLength = 50, IsPrimary = true, IsNullable = false)]
  public required string User_Cd { get; set; }

  [JsonProperty, Column(Name = "approval_status", StringLength = 50)]
  public string? Approval_Status { get; set; }

  [JsonProperty, Column(Name = "approved_by", StringLength = 50)]
  public string? Approved_By { get; set; }

  [JsonProperty, Column(Name = "approved_date", DbType = "timestamptz")]
  public DateTime? Approved_Date { get; set; }

  [JsonProperty, Column(Name = "approver_reason", StringLength = 100)]
  public string? Approver_Reason { get; set; }

  [JsonProperty, Column(Name = "can_assign")]
  public bool? Can_Assign { get; set; }

  [JsonProperty, Column(Name = "can_change_actions")]
  public bool? Can_Change_Actions { get; set; }

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_active { get; set; } = false;

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "request_by", StringLength = 50)]
  public string? Request_By { get; set; }

  [JsonProperty, Column(Name = "request_justification", StringLength = 100)]
  public string? Request_Justification { get; set; }

  [JsonProperty, Column(Name = "user_role_id", IsIdentity = true, InsertValueSql = "nextval('asf.user_role_user_role_id_seq'::regclass)")]
  public int User_Role_Id { get; set; }

}
