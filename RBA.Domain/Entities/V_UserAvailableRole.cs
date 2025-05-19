using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.fn_get_user_available_role", DisableSyncStructure = true)]
public class V_UserAvailableRole
{

  [JsonProperty, Column(Name = "application_cd")]
  public string? ApplicationCd { get; set; }

  [JsonProperty, Column(Name = "app_description")]
  public string? AppDescription { get; set; }

  [JsonProperty, Column(Name = "role_id")]
  public int? RoleId { get; set; }

  [JsonProperty, Column(Name = "role_name")]
  public string? RoleName { get; set; }

  [JsonProperty, Column(Name = "role_description")]
  public string? RoleDescription { get; set; }

  [JsonProperty, Column(Name = "plant_cd")]
  public string? PlantCd { get; set; }
}


