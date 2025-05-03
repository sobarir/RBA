using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.application", DisableSyncStructure = true)]
public partial class Application : IEntity
{

  [JsonProperty, Column(Name = "application_cd", StringLength = 3, IsPrimary = true, IsNullable = false)]
  public required string Application_Cd { get; set; }

  [JsonProperty, Column(Name = "application_owner", StringLength = 50, IsNullable = false)]
  public required string Application_Owner { get; set; }

  [JsonProperty, Column(Name = "description", StringLength = 150)]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_active { get; set; } = false;

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "pin_validity_minutes")]
  public int? Pin_Validity_Minutes { get; set; }

  [JsonProperty, Column(Name = "requires_2fa")]
  public bool? Requires_2fa { get; set; }

}
