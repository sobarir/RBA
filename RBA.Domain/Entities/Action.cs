using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.action", DisableSyncStructure = true)]
public partial class Action : IEntity
{

  [JsonProperty, Column(Name = "action_id", IsPrimary = true, IsIdentity = true)]
  public required int Action_Id { get; set; }

  [JsonProperty, Column(Name = "application_cd", DbType = "varchar(3)", IsNullable = false)]
  public string? Application_Cd { get; set; }

  [JsonProperty, Column(Name = "created_date")]
  public DateTime Created_Date { get; set; }

  [JsonProperty, Column(Name = "description", DbType = "varchar(100)")]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool? Is_Active { get; set; } = true;

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "name", DbType = "varchar(100)")]
  public string? Name { get; set; }

}

