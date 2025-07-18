using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IAuditTrailRepository : IRepositoryBase<AuditTrail>
{

  Task<IEnumerable<AuditTrail>> GetAllByTableAsync(string table_name);

  Task<AuditTrail> GetJsonByIdAsync(int id);

}
