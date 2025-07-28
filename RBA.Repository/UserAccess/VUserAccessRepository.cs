using Microsoft.Extensions.Logging;
using RBA.Domain.Entities;

namespace RBA.Repository.UserAccess;

public class VUserAccessRepository(IFreeSql sql, ILogger<RepositoryBase<V_UserAccess>> logger)
  : RepositoryBase<V_UserAccess>(sql, logger), IVUserAccessRepository
{

  public async Task<IEnumerable<V_UserAccess>> GetAllAsync(string user_cd, string app_code)
  {
    return await _sql.Select<V_UserAccess>()
      .Where(a => a.User_Cd == user_cd && a.Application_Cd == app_code)
      .ToListAsync();
  }

  Task<IEnumerable<V_UserAccess>> IRepositoryBase<V_UserAccess>.GetAllAsync()
  {
    throw new NotImplementedException();
  }

  Task<V_UserAccess?> IRepositoryBase<V_UserAccess>.GetAsync(object? id)
  {
    throw new NotImplementedException();
  }

}
