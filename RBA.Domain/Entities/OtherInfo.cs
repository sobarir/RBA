using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.other_info", DisableSyncStructure = true)]
public partial class OtherInfo
{

  [JsonProperty, Column(Name = "info_id", IsPrimary = true, IsIdentity = true, InsertValueSql = "nextval('asf.other_info_info_id_seq'::regclass)")]
  public int Info_Id { get; set; }

  [JsonProperty, Column(Name = "info_name", StringLength = 100, IsNullable = false)]
  public string? Info_Name { get; set; }

  [JsonProperty, Column(Name = "info_type", StringLength = 30, IsNullable = false)]
  public string? Info_Type { get; set; }

  [JsonProperty, Column(Name = "info_value1", StringLength = 100)]
  public string? Info_Value1 { get; set; }

  [JsonProperty, Column(Name = "info_value2", StringLength = 100)]
  public string? Info_Value2 { get; set; }

  [JsonProperty, Column(Name = "sort_order")]
  public int Sort_Order { get; set; }

}
