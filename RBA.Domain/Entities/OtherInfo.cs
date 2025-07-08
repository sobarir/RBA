using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.other_info", DisableSyncStructure = true)]
public partial class OtherInfo : IEntity
{

  [JsonProperty, Column(Name = "info_id", IsPrimary = true, IsIdentity = true)]
  public required int Info_Id { get; set; }

  [JsonProperty, Column(Name = "info_name", DbType = "varchar(100)")]
  public string? Info_Name { get; set; }

  [JsonProperty, Column(Name = "info_type", DbType = "varchar(30)")]
  public string? Info_Type { get; set; }

  [JsonProperty, Column(Name = "info_value1", DbType = "varchar(100)")]
  public string? Info_Value1 { get; set; }

  [JsonProperty, Column(Name = "info_value2", DbType = "varchar(100)")]
  public string? Info_Value2 { get; set; }

  [JsonProperty, Column(Name = "sort_order")]
  public int? Sort_Order { get; set; }

}
