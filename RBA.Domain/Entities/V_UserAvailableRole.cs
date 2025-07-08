using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.fn_get_user_available_role", DisableSyncStructure = true)]
public class V_UserAvailableRole
{

  [JsonProperty, Column(Name = "application_cd")]
  public string? Application_Cd { get; set; }

  [JsonProperty, Column(Name = "app_description")]
  public string? App_Description { get; set; }

  [JsonProperty, Column(Name = "role_id")]
  public int? Role_Id { get; set; }

  [JsonProperty, Column(Name = "role_name")]
  public string? Role_Name { get; set; }

  [JsonProperty, Column(Name = "role_description")]
  public string? Role_Description { get; set; }

  [JsonProperty, Column(Name = "plant_cd")]
  public string? Plant_Cd { get; set; }
}


