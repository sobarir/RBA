using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.role_plant", DisableSyncStructure = true)]
public partial class RolePlant : IEntity
{

  [JsonProperty, Column(Name = "role_id", IsPrimary = true, IsIdentity = true, InsertValueSql = "nextval('asf.role_plant_role_id_seq'::regclass)")]
  public required int Role_Id { get; set; }

  [JsonProperty, Column(Name = "application_cd", StringLength = 3, IsNullable = false)]
  public required string Application_Cd { get; set; }

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "description", StringLength = 150)]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_active { get; set; } = false;

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "plant_cd", StringLength = 10)]
  public string? Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "role_name", StringLength = 100, IsNullable = false)]
  public required string Role_Name { get; set; }

}
