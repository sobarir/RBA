using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.user_allowed_plant", DisableSyncStructure = true)]
public partial class UserAllowedPlant : IEntity
{

  [JsonProperty, Column(Name = "user_cd", StringLength = 50, IsPrimary = true, IsNullable = false)]
  public required string User_Cd { get; set; }

  [JsonProperty, Column(Name = "plant_cd", StringLength = 10, IsPrimary = true, IsNullable = false)]
  public required string Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_active { get; set; } = false;

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Last_Edit_Date { get; set; }

}
