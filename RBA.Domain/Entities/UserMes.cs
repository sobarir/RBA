using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "asf.user_mes", DisableSyncStructure = true)]
public partial class UserMes : IEntity
{

  [JsonProperty, Column(Name = "user_cd", StringLength = 50, IsPrimary = true, IsNullable = false)]
  public required string User_Cd { get; set; }

  [JsonProperty, Column(Name = "badge_code", StringLength = 1000)]
  public required string Badge_Code { get; set; }

  [JsonProperty, Column(Name = "certification_bytes")]
  public byte[]? Certification_Bytes { get; set; }

  [JsonProperty, Column(Name = "certification_password", StringLength = -2)]
  public string? Certification_Password { get; set; }

  [JsonProperty, Column(Name = "certification_valid_end", DbType = "timestamptz")]
  public DateTime? Certification_Valid_End { get; set; }

  [JsonProperty, Column(Name = "certification_valid_start", DbType = "timestamptz")]
  public DateTime? Certification_Valid_Start { get; set; }

  [JsonProperty, Column(Name = "created_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "default_plant_cd", StringLength = 10, IsNullable = false)]
  public required string Default_Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "email", StringLength = 100)]
  public string? Email { get; set; }

  [JsonProperty, Column(Name = "first_name", StringLength = 50, IsNullable = false)]
  public required string First_Name { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_active { get; set; } = false;

  [JsonProperty, Column(Name = "language_cd", StringLength = 10, IsNullable = false)]
  public required string Language_Cd { get; set; }

  [JsonProperty, Column(Name = "last_edit_date", DbType = "timestamptz", InsertValueSql = "CURRENT_TIMESTAMP")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "last_name", StringLength = 50, IsNullable = false)]
  public required string Last_Name { get; set; }

  [JsonProperty, Column(Name = "phone", StringLength = -2)]
  public string? Phone { get; set; }

  [JsonProperty, Column(Name = "pin", StringLength = -2)]
  public string? Pin { get; set; }

  [JsonProperty, Column(Name = "pin_expiration_date", DbType = "timestamptz")]
  public DateTime? Pin_Expiration_Date { get; set; }

  [JsonProperty, Column(Name = "pin_set_date", DbType = "timestamptz")]
  public DateTime? Pin_Set_Date { get; set; }

}
