using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IVUserRolePlantRepository : IRepositoryBase<V_UserRolePlant>
{

  Task<IEnumerable<V_UserRolePlant>> GetAllAsync(string user_cd);
  Task<IEnumerable<V_UserRolePlant>> GetAllByIdAsync(int user_role_id);

}
