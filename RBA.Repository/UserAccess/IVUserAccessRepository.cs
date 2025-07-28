using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IVUserAccessRepository : IRepositoryBase<V_UserAccess>
{

  Task<IEnumerable<V_UserAccess>> GetAllAsync(string user_cd, string app_code);

}
