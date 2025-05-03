using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IUserAllowedPlantRepository : IRepositoryBase<UserAllowedPlant>
{
  Task<UserAllowedPlant> GetAsync(string user_cd, string plant_cd);
  Task<bool> DeleteAsync(string user_cd, string plant_cd);
}
