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

  public async Task<IEnumerable<OtherInfo>> GetAllAsync(string info_type, string info_name)
  {

    return await _sql.Ado.CommandFluent("select * from rba.fn_get_other_info (@in_info_type, @in_info_name)")
      //.CommandType(CommandType.StoredProcedure)
      .CommandTimeout(60)
      .WithParameter("in_info_type", info_type)
      .WithParameter("in_info_name", info_name)
      .QueryAsync<OtherInfo>();

  }

  public async Task<V_UserRoleAllInfo> GetAllInfoByIdAsync(int user_role_id)
  {
    return await _sql.Select<V_UserRoleAllInfo>()
      .Where(a => a.User_Role_Id == user_role_id)
      .ToOneAsync();
  }

}
