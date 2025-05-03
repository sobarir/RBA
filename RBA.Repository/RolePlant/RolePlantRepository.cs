using Microsoft.Extensions.Logging;
using RBA.Domain.Entities;

namespace RBA.Repository;

public class RolePlantRepository(IFreeSql sql, ILogger<RolePlantRepository> logger) 
  : RepositoryBase<RolePlant>(sql, logger), IRolePlantRepository
{

  public override Task<RolePlant> CreateAsync(RolePlant entity)
  {
    return CreateIdentityAsync(entity);
  }

  public async Task<IEnumerable<RolePlant>> GetAllByPlantAsync(string plant_cd)
  {
    return await _sql.Select<RolePlant>()
      .Where(a => a.Plant_Cd == plant_cd)
      .ToListAsync();
  }

  public async Task<IEnumerable<RolePlant>> GetAllByAppAsync(string application_cd)
  {
    return await _sql.Select<RolePlant>()
      .Where(a => a.Application_Cd == application_cd)
      .ToListAsync();
  }

}
