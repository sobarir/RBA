using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IUserRoleRepository : IRepositoryBase<UserRole>
{
  Task<UserRole> GetAsync(int role_id, string user_cd);

  Task<UserRole> GetByIdAsync(int user_role_id);

  Task<bool> DeleteAsync(int role_id, string user_cd);

  Task<IEnumerable<UserRole>> GetAllAsync(string user_cd, int month);
}
