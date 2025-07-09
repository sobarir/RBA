using Microsoft.Extensions.Logging;

using RBA.Domain;
using RBA.Domain.Entities;

namespace RBA.Repository;

public class UserAllowedPlantRepository(IFreeSql sql, ILogger<RepositoryBase<UserAllowedPlant>> logger) 
  : RepositoryBase<UserAllowedPlant>(sql, logger), IUserAllowedPlantRepository
{
  public async Task<UserAllowedPlant> GetAsync(string user_cd, string plant_cd)
  {
    return await _sql.Select<UserAllowedPlant>()
      .Where(a => a.User_Cd == user_cd && a.Plant_Cd == plant_cd)
      .ToOneAsync();
  }

  public async Task<bool> DeleteAsync(string user_cd, string plant_cd)
  {
    _logger.LogInformation("DeleteAsync {user_cd} and {plant_cd}", user_cd, plant_cd);
    return await _sql.Delete<UserAllowedPlant>()
      //.Where(a => a.User_Cd == user_cd && a.Plant_Cd == plant_cd)
      .ExecuteAffrowsAsync() > 0;
  }

  public override async Task<bool> UpdateAsync(UserAllowedPlant entity)
  {
    _logger.LogInformation("UpdateAsync {entity}", entity.ToJson());
    return await _sql.Update<UserAllowedPlant>()
      .SetSourceIgnore(entity, col => col == null)
      //.Where(a => a.User_Cd == entity.User_Cd && a.Plant_Cd == entity.Plant_Cd)
      .ExecuteAffrowsAsync() > 0;
  }

  public override Task<bool> DeleteAsync(object? id)
  {
    throw new NotImplementedException();
  }

  public override Task<UserAllowedPlant?> GetAsync(object? id)
  {
    throw new NotImplementedException();
  }

}
