using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IVUserActionRepository : IRepositoryBase<V_UserAction>
{

  Task<IEnumerable<V_UserAction>> GetAllAsync(string user_cd, int action_id);

}
