using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn)]
public class V_UserAvailableRole
{
  [JsonProperty("application_cd")]
  public string? ApplicationCd { get; set; }

  [JsonProperty("app_description")]
  public string? AppDescription { get; set; }

  [JsonProperty("role_id")]
  public int? RoleId { get; set; }

  [JsonProperty("role_name")]
  public string? RoleName { get; set; }

  [JsonProperty("role_description")]
  public string? RoleDescription { get; set; }

  [JsonProperty("plant_cd")]
  public string? PlantCd { get; set; }
}


