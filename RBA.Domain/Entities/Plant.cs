using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace RBA.Domain.Entities {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "mas.plant", DisableSyncStructure = true)]
	public partial class MasPlant {

		[JsonProperty, Column(Name = "id", IsPrimary = true)]
		public Guid Id { get; set; }

		[JsonProperty, Column(Name = "color", StringLength = 50)]
		public string? Color { get; set; }

		[JsonProperty, Column(Name = "created_date")]
		public DateTime CreatedDate { get; set; }

		[JsonProperty, Column(Name = "date_format_long", StringLength = 50)]
		public string? DateFormatLong { get; set; }

		[JsonProperty, Column(Name = "date_format_short", StringLength = 50)]
		public string? DateFormatShort { get; set; }

		[JsonProperty, Column(Name = "description")]
		public string? Description { get; set; }

		[JsonProperty, Column(Name = "is_active")]
		public bool? IsActive { get; set; }

		[JsonProperty, Column(Name = "last_edit_date")]
		public DateTime LastEditDate { get; set; }

		[JsonProperty, Column(Name = "last_edit_user_cd", StringLength = 50)]
		public string? LastEditUserCd { get; set; }

		[JsonProperty, Column(Name = "pin_length")]
		public int? PinLength { get; set; }

		[JsonProperty, Column(Name = "pin_reset_days")]
		public int? PinResetDays { get; set; }

		[JsonProperty, Column(Name = "plant_cd", StringLength = 50, IsNullable = false)]
		public string? PlantCd { get; set; }

		[JsonProperty, Column(Name = "region_cd", StringLength = 50, IsNullable = false)]
		public string? RegionCd { get; set; }

		[JsonProperty, Column(Name = "time_format_long", StringLength = 50)]
		public string? TimeFormatLong { get; set; }

		[JsonProperty, Column(Name = "time_format_short", StringLength = 50)]
		public string? TimeFormatShort { get; set; }

		[JsonProperty, Column(Name = "timezone", StringLength = 50, IsNullable = false)]
		public string? Timezone { get; set; }

	}

}
