using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IVUserRolePlantRepository : IRepositoryBase<V_UserRolePlant>
{

  Task<IEnumerable<V_UserRolePlant>> GetAllAsync(string user_cd);
  
  Task<IEnumerable<V_UserRolePlant>> GetAllByIdAsync(int user_role_id);

  Task<List<V_UserAvailableRole>> GetAllUserAvailableRolesAsync(string user_cd, string app_code);

  Task<List<V_RequestByOwner>> GetRequestByOwnerAsync(string owner_cd);

}
