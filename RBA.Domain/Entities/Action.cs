using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.action", DisableSyncStructure = true)]
public partial class Action : IEntity
{

  [JsonProperty, Column(Name = "action_id", IsPrimary = true, IsIdentity = true, InsertValueSql = "nextval('asf.action_action_id_seq'::regclass)")]
  public int Action_Id { get; set; }

  [JsonProperty, Column(Name= "application_cd", StringLength = 3, IsNullable = false)]
  public required string Application_Cd { get; set; }

  [JsonProperty, Column(Name = "name", StringLength = 100, IsNullable = false)]
  public required string Name { get; set; }

  [JsonProperty, Column(Name = "description")]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_Active { get; set; } = false;

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Last_Edit_Date { get; set; }

}

