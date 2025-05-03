using Microsoft.Extensions.Logging;

using RBA.Domain;
using RBA.Domain.Entities;

namespace RBA.Repository;

public class UserRoleRepository(IFreeSql sql, ILogger<RepositoryBase<UserRole>> logger) 
  : RepositoryBase<UserRole>(sql, logger), IUserRoleRepository
{
  public async Task<UserRole> GetAsync(int role_id, string user_cd)
  {
    return await _sql.Select<UserRole>()
      .Where(a => a.Role_Id == role_id && a.User_Cd == user_cd)
      .ToOneAsync();
  }

  public async Task<UserRole> GetByIdAsync(int user_role_id)
  {
    return await _sql.Select<UserRole>()
      .Where(a => a.User_Role_Id == user_role_id)
      .ToOneAsync();
  }

  public async Task<bool> DeleteAsync(int role_id, string user_cd)
  {
    _logger.LogInformation("DeleteAsync {role_id} and {user_cd}", role_id, user_cd);
    return await _sql.Delete<UserRole>()
      .Where(a => a.Role_Id == role_id && a.User_Cd == user_cd)
      .ExecuteAffrowsAsync() > 0;
  }

  public override async Task<bool> UpdateAsync(UserRole entity)
  {
    _logger.LogInformation("UpdateAsync {entity}", entity.ToJson());
    return await _sql.Update<UserRole>()
      .SetSourceIgnore(entity, col => col == null)
      .Where(a => a.Role_Id == entity.Role_Id && a.User_Cd == entity.User_Cd)
      .ExecuteAffrowsAsync() > 0;
  }

  public async Task<IEnumerable<UserRole>> GetAllAsync(string user_cd, int month)
  {
    return await _sql.Select<UserRole>()
      .Where(a => a.User_Cd == user_cd && a.Created_Date!.Value.Month <= month)
      .ToListAsync();
  }

  public override Task<bool> DeleteAsync(object? id)
  {
    throw new NotImplementedException();
  }

  public override Task<UserRole?> GetAsync(object? id)
  {
    throw new NotImplementedException();
  }

}
