using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.v_application_role_action", DisableSyncStructure = true)]
public partial class V_ApplicationRoleAction : IEntity
{

  [JsonProperty, Column(Name = "action_id")]
  public int? Action_Id { get; set; }

  [JsonProperty, Column(Name = "application_cd", StringLength = 3)]
  public string? Application_Cd { get; set; }

  [JsonProperty, Column(Name = "application_owner", StringLength = 50)]
  public string? Application_Owner { get; set; }

  [JsonProperty, Column(Name = "decription_rol")]
  public string? Decription_Rol { get; set; }

  [JsonProperty, Column(Name = "description", StringLength = 150)]
  public string? description { get; set; }

  [JsonProperty, Column(Name = "description_action")]
  public string? Description_Action { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool? Is_Active { get; set; }

  [JsonProperty, Column(Name = "is_active_action")]
  public bool? Is_Active_Action { get; set; }

  [JsonProperty, Column(Name = "is_active_application")]
  public bool? Is_Active_Application { get; set; }

  [JsonProperty, Column(Name = "is_active_role_action")]
  public bool? Is_Active_Role_Action { get; set; }

  [JsonProperty, Column(Name = "name", StringLength = 100)]
  public string? Name { get; set; }

  [JsonProperty, Column(Name = "role_id")]
  public int? Role_Id { get; set; }

  [JsonProperty, Column(Name = "role_name", StringLength = 100)]
  public string? Role_Name { get; set; }

}
