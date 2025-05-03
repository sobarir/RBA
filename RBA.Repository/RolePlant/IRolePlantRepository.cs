using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IRolePlantRepository : IRepositoryBase<RolePlant>
{

  Task<IEnumerable<RolePlant>> GetAllByPlantAsync(string plant_cd);

}
