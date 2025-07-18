using FreeSql.DataAnnotations;
using Newtonsoft.Json;

namespace RBA.Domain.Entities;

[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.user_mes", DisableSyncStructure = true)]
public partial class UserMes : IEntity
{

  [JsonProperty, Column(Name = "user_cd", DbType = "varchar(50)", IsPrimary = true, IsNullable = false)]
  public required string User_Cd { get; set; }

  [JsonProperty, Column(Name = "badge_code", DbType = "varchar(1000)")]
  public string? Badge_Code { get; set; }

  [JsonProperty, Column(Name = "certification_bytes")]
  public bool? Certification_Bytes { get; set; }

  [JsonProperty, Column(Name = "certification_password", DbType = "varchar(50)")]
  public string? Certification_Password { get; set; }

  [JsonProperty, Column(Name = "certification_valid_end")]
  public DateTime? Certification_Valid_End { get; set; }

  [JsonProperty, Column(Name = "certification_valid_start")]
  public DateTime? Certification_Valid_Start { get; set; }

  [JsonProperty, Column(Name = "created_date")]
  public DateTime? Created_Date { get; set; }

  [JsonProperty, Column(Name = "default_plant_cd", DbType = "varchar(10)", IsNullable = false)]
  public string? Default_Plant_Cd { get; set; }

  [JsonProperty, Column(Name = "email", DbType = "varchar(100)")]
  public string? Email { get; set; }

  [JsonProperty, Column(Name = "first_name", DbType = "varchar(50)", IsNullable = false)]
  public string? First_Name { get; set; }

  [JsonProperty, Column(Name = "is_active")]
  public bool Is_Active { get; set; } = true;

  [JsonProperty, Column(Name = "language_cd", DbType = "varchar(10)", IsNullable = false)]
  public string? Language_Cd { get; set; }

  [JsonProperty, Column(Name = "last_edit_date")]
  public DateTime? Last_Edit_Date { get; set; }

  [JsonProperty, Column(Name = "last_name", DbType = "varchar(50)", IsNullable = false)]
  public string? Last_Name { get; set; }

  [JsonProperty, Column(Name = "phone", DbType = "varchar(50)")]
  public string? Phone { get; set; }

  [JsonProperty, Column(Name = "pin", DbType = "varchar(50)")]
  public string? Pin { get; set; }

  [JsonProperty, Column(Name = "pin_expiration_date")]
  public DateTime? Pin_Expiration_Date { get; set; }

  [JsonProperty, Column(Name = "pin_set_date")]
  public DateTime? Pin_Set_Date { get; set; }

  [JsonProperty, Column(Name = "modified_by", DbType = "varchar(50)")]
  public string? Modified_By { get; set; }

}
