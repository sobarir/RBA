using Microsoft.Extensions.Logging;

using RBA.Domain;
using RBA.Domain.Entities;

namespace RBA.Repository;

public class RoleActionRepository(IFreeSql sql, ILogger<RepositoryBase<RoleAction>> logger) 
  : RepositoryBase<RoleAction>(sql, logger), IRoleActionRepository
{
  public async Task<RoleAction> GetAsync(int role_id, int action_id)
  {
    return await _sql.Select<RoleAction>()
      .Where(a => a.Role_Id == role_id && a.Action_Id == action_id)
      .ToOneAsync();
  }

  public async Task<IEnumerable<RoleAction>> GetByRoleIdAsync(int role_id)
  {
    return await _sql.Select<RoleAction>()
      .Where(a => a.Role_Id == role_id)
      .ToListAsync();
  }

  public async Task<bool> DeleteAsync(int role_id, int action_id)
  {
    _logger.LogInformation("DeleteAsync {role_id} and {action_id}", role_id, action_id);
    return await _sql.Delete<RoleAction>()
      //.Where(a => a.Role_Id == role_id && a.Action_Id == action_id)
      .ExecuteAffrowsAsync() > 0;
  }

  public override async Task<bool> UpdateAsync(RoleAction entity)
  {
    _logger.LogInformation("UpdateAsync {entity}", entity.ToJson());
    return await _sql.Update<RoleAction>()
      .SetSourceIgnore(entity, col => col == null)
      //.Where(a => a.Role_Id == entity.Role_Id && a.Action_Id == entity.Action_Id)
      .ExecuteAffrowsAsync() > 0;
  }

  public override Task<bool> DeleteAsync(object? id)
  {
    throw new NotImplementedException();
  }

  public override Task<RoleAction?> GetAsync(object? id)
  {
    throw new NotImplementedException();
  }

}
