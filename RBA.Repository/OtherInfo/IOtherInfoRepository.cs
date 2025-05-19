using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IOtherInfoRepository : IRepositoryBase<OtherInfo>
{

  Task<IEnumerable<OtherInfo>> GetAllAsync(string info_type, string info_name);

  Task<List<V_UserRoleAllInfo>> GetAllInfoByIdAsync(int user_role_id);

}
