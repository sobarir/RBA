using Microsoft.Extensions.Logging;
using RBA.Domain.Entities;
using System.Data;

namespace RBA.Repository;

public class OtherInfoRepository(IFreeSql sql, ILogger<OtherInfoRepository> logger) 
  : RepositoryBase<OtherInfo>(sql, logger), IOtherInfoRepository
{

  public override Task<OtherInfo> CreateAsync(OtherInfo entity)
  {
    return CreateIdentityAsync(entity);
  }

  public async Task<IEnumerable<OtherInfo>> GetAllByTypeAsync(string info_type)
  {
    return await _sql.Select<OtherInfo>()
      .Where(a => a.Info_Type == info_type)
      .ToListAsync();
  }

  public async Task<IEnumerable<OtherInfo>> GetSMTPInfoAsync()
  {
    return await GetAllByTypeAsync("asf_smtp");
  }

  public async Task<IEnumerable<OtherInfo>> GetApprvInfoAsync()
  {
    return await GetAllByTypeAsync("asf_apprv");
  }

  public async Task<IEnumerable<OtherInfo>> GetEmailInfoAsync()
  {
    return await GetAllByTypeAsync("asf_email");
  }

  public async Task<IEnumerable<OtherInfo>> GetAllAsync(string info_type, string info_name)
  {

    return await _sql.Ado.CommandFluent("select * from rba.fn_get_other_info (@in_info_type, @in_info_name)")
      .CommandTimeout(60)
      .WithParameter("in_info_type", info_type)
      .WithParameter("in_info_name", info_name)
      .QueryAsync<OtherInfo>();

  }

  public async Task<V_UserRoleAllInfo> GetAllInfoByIdAsync(int user_role_id)
  {

    return await _sql.Ado.CommandFluent("select * from rba.fn_get_all_info_by_id (@in_user_role_id)")
      .CommandTimeout(60)
      .WithParameter("in_user_role_id", user_role_id)
      .QuerySingleAsync<V_UserRoleAllInfo>();

  }

}
