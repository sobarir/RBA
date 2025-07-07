using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "application", DisableSyncStructure = true)]
public partial class Application : IEntity
{

  [JsonProperty, Column(Name = "application_Cd", DbType = "varchar(3)", IsPrimary = true, IsNullable = false)]
  public required string Application_Cd { get; set; }

  [JsonProperty, Column(Name = "application_owner", DbType = "varchar(50)")]
  public string? Application_Owner { get; set; }

  [JsonProperty, Column(Name = "created_date")]
  public DateTime Created_Date { get; set; }

  [JsonProperty, Column(Name = "description", DbType = "varchar(100)")]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public int? Is_Active { get; set; } = 1;

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "pin_validity_minutes")]
  public int? Pin_Validity_Minutes { get; set; }

  [JsonProperty, Column(Name = "requires_2fa")]
  public bool? Requires_2fa { get; set; }

}
