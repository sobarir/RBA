using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.user_allowed_plant", DisableSyncStructure = true)]
public partial class UserAllowedPlant : IEntity
{

  [JsonProperty, Column(Name = "plant_cd", DbType = "varchar(10)", IsPrimary = true, IsNullable = false)]
  public required string Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "user_cd", DbType = "varchar(50)", IsPrimary = true, IsNullable = false)]
  public required string User_Cd { get; set; }

  [JsonProperty, Column(Name = "created_date")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool? Is_Active { get; set; } = true;

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

}
