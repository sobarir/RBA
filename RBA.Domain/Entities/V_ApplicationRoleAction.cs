using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.v_application_role_action", DisableSyncStructure = true)]
public partial class V_ApplicationRoleAction : IEntity
{

  [JsonProperty, Column(Name = "action_id")]
  public int Action_Id { get; set; }

  [JsonProperty, Column(Name = "application_cd", DbType = "varchar(3)", IsNullable = false)]
  public string? Application_Cd { get; set; }

  [JsonProperty, Column(Name = "application_owner", DbType = "varchar(50)")]
  public string? Application_Owner { get; set; }

  [JsonProperty, Column(Name = "decription_rol", DbType = "varchar(100)")]
  public string? Decription_Rol { get; set; }

  [JsonProperty, Column(Name = "description", DbType = "varchar(100)")]
  public string? Description { get; set; }

  [JsonProperty, Column(Name = "description_action", DbType = "varchar(100)")]
  public string? Description_Action { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool? Is_Active { get; set; }

  [JsonProperty, Column(Name = "is_active_action")]
  public bool? Is_Active_Action { get; set; }

  [JsonProperty, Column(Name = "is_active_application")]
  public int? Is_Active_Application { get; set; }

  [JsonProperty, Column(Name = "is_active_role_action")]
  public bool? Is_Active_Role_Action { get; set; }

  [JsonProperty, Column(Name = "name", DbType = "varchar(100)")]
  public string? Name { get; set; }

  [JsonProperty, Column(Name = "role_id")]
  public int Role_Id { get; set; }

  [JsonProperty, Column(Name = "role_name", DbType = "varchar(100)", IsNullable = false)]
  public string? Role_Name { get; set; }

}
