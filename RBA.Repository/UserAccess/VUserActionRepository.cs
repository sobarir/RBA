using Microsoft.Extensions.Logging;
using RBA.Domain.Entities;

namespace RBA.Repository.UserAccess;

public class VUserActionRepository(IFreeSql sql, ILogger<RepositoryBase<V_UserAction>> logger)
  : RepositoryBase<V_UserAction>(sql, logger), IVUserActionRepository
{

  public async Task<IEnumerable<V_UserAction>> GetAllAsync(string user_cd, int action_id)
  {
    return await _sql.Select<V_UserAction>()
      .Where(a => a.User_Cd == user_cd && a.Action_Id == action_id)
      .ToListAsync();
  }

}
