using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.role_plant", DisableSyncStructure = true)]
public partial class RolePlant : IEntity
{

  [JsonProperty, Column(Name = "role_id", IsPrimary = true, IsIdentity = true)]
  public required int Role_Id { get; set; }

  [JsonProperty, Column(Name = "application_cd", DbType = "varchar(3)", IsNullable = false)]
  public string? Application_Cd { get; set; }

  [JsonProperty, Column(Name = "approval_status", DbType = "varchar(100)")]
  public string? Approval_Status { get; set; }

  [JsonProperty, Column(Name = "approved_by", DbType = "varchar(50)")]
  public string? Approved_By { get; set; }

  [JsonProperty, Column(Name = "approved_date")]
  public DateTime? Approved_Date { get; set; }

  [JsonProperty, Column(Name = "approver_reason", DbType = "varchar(100)")]
  public string? Approver_Reason { get; set; }

  [JsonProperty, Column(Name = "created_date")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "description", DbType = "varchar(100)")]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool? Is_Active { get; set; } = true;

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "plant_cd", DbType = "varchar(10)", IsNullable = false)]
  public string? Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "request_by", DbType = "varchar(50)")]
  public string? Request_By { get; set; }

  [JsonProperty, Column(Name = "request_justification", DbType = "varchar(100)")]
  public string? Request_Justification { get; set; }

  [JsonProperty, Column(Name = "role_Name", DbType = "varchar(100)", IsNullable = false)]
  public string? Role_Name { get; set; }

}
