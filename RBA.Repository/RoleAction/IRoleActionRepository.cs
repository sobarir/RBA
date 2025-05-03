using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IRoleActionRepository : IRepositoryBase<RoleAction>
{
  Task<RoleAction> GetAsync(int role_id, int action_id);
  Task<bool> DeleteAsync(int role_id, int action_id);
}
