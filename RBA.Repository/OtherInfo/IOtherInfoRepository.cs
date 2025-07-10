using RBA.Domain.Entities;

namespace RBA.Repository;

public interface IOtherInfoRepository : IRepositoryBase<OtherInfo>
{

  Task<IEnumerable<OtherInfo>> GetAllAsync(string info_type, string info_name);

  Task<IEnumerable<OtherInfo>> GetAllByTypeAsync(string info_type);

  Task<IEnumerable<OtherInfo>> GetSMTPInfoAsync();

  Task<IEnumerable<OtherInfo>> GetApprvInfoAsync();

  Task<IEnumerable<OtherInfo>> GetEmailInfoAsync();

  Task<V_UserRoleAllInfo> GetAllInfoByIdAsync(int user_role_id);

}
