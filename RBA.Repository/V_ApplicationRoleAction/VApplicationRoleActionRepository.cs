using Microsoft.Extensions.Logging;

using RBA.Domain.Entities;

namespace RBA.Repository;

public class VApplicationRoleActionRepository(IFreeSql sql, ILogger<RepositoryBase<V_UserRolePlant>> logger) 
  : RepositoryBase<V_UserRolePlant>(sql, logger), IVApplicationRoleActionRepository
{

  public async Task<IEnumerable<V_ApplicationRoleAction>> GetAllAsync(string[]? apps)
  {
    if (apps == null || apps.Length == 0) throw new ArgumentNullException(nameof(apps));

    return await _sql.Select<V_ApplicationRoleAction>()
      .Where(a => apps.Contains(a.Application_Cd))
      .ToListAsync();
  }

  public Task<V_ApplicationRoleAction> CreateAsync(V_ApplicationRoleAction entity)
  {
    throw new NotImplementedException();
  }

  public Task<bool> UpdateAsync(V_ApplicationRoleAction entity)
  {
    throw new NotImplementedException();
  }

  Task<IEnumerable<V_ApplicationRoleAction>> IRepositoryBase<V_ApplicationRoleAction>.GetAllAsync()
  {
    throw new NotImplementedException();
  }

  Task<V_ApplicationRoleAction?> IRepositoryBase<V_ApplicationRoleAction>.GetAsync(object? id)
  {
    throw new NotImplementedException();
  }

}
