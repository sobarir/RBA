using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "role_action", DisableSyncStructure = true)]
public partial class RoleAction : IEntity
{

  [JsonProperty, Column(Name = "action_id", IsPrimary = true)]
  public required int Action_Id { get; set; }

  [JsonProperty, Column(Name = "role_id", IsPrimary = true)]
  public int Role_Id { get; set; }

  [JsonProperty, Column(Name = "created_date")]
  public DateTime Created_Date { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool? Is_Active { get; set; } = true;

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

}
