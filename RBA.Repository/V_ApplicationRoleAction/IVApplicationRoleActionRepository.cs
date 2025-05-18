using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IVApplicationRoleActionRepository : IRepositoryBase<V_ApplicationRoleAction>
{

  Task<IEnumerable<V_ApplicationRoleAction>> GetAllAsync(string[]? apps);

}
