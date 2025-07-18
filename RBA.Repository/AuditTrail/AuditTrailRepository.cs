using Microsoft.Extensions.Logging;
using RBA.Domain.Entities;

namespace RBA.Repository;

public class AuditTrailRepository(IFreeSql sql, ILogger<AuditTrailRepository> logger)
  : RepositoryBase<AuditTrail>(sql, logger), IAuditTrailRepository
{

  public override async Task<IEnumerable<AuditTrail>> GetAllAsync()
  {
    return await _sql.Ado.CommandFluent("select * from rba.fn_get_all_audit_trail ()")
      .CommandTimeout(60)
      .QueryAsync<AuditTrail>();
  }

  public async Task<IEnumerable<AuditTrail>> GetAllByTableAsync(string table_name)
  {
    return await _sql.Ado.CommandFluent("select * from rba.fn_get_all_audit_trail_by_table (@in_table_name)")
      .CommandTimeout(60)
      .WithParameter("in_table_name", table_name)
      .QueryAsync<AuditTrail>();
  }

  public async Task<AuditTrail> GetJsonByIdAsync(int id)
  {
    return await _sql.Ado.CommandFluent("select * from rba.fn_get_all_audit_trail_json (@in_id)")
      .CommandTimeout(60)
      .WithParameter("in_id", id)
      .QuerySingleAsync<AuditTrail>();
  }

}
