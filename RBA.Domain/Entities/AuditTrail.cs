using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace RBA.Domain.Entities {

	[JsonObject(MemberSerialization.OptIn), Table(Name = "rba.audit_trail", DisableSyncStructure = true)]
	public partial class AuditTrail : IEntity {

		[JsonProperty, Column(IsPrimary = true, IsIdentity = true)]
		public long Id { get; set; }

		[JsonProperty, Column(Name = "action_type", DbType = "varchar(10)", IsNullable = false)]
		public string? Action_type { get; set; }

		[JsonProperty, Column(Name = "after_data", StringLength = 1000)]
		public string? After_data { get; set; }

		[JsonProperty, Column(Name = "before_data", StringLength = 1000)]
		public string? Before_data { get; set; }

		[JsonProperty, Column(Name = "changed_at")]
		public DateTime? Changed_at { get; set; }

		[JsonProperty, Column(Name = "changed_by", DbType = "varchar(255)", IsNullable = false)]
		public string? Changed_by { get; set; }

		[JsonProperty, Column(Name = "record_id", DbType = "varchar(50)")]
		public string? Record_id { get; set; }

		[JsonProperty, Column(Name = "table_name", DbType = "varchar(50)", IsNullable = false)]
		public string? Table_name { get; set; }

	}

}
