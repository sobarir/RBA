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

  public async Task<IEnumerable<OtherInfo>> GetAllAsync(string info_type, string info_name)
  {

    return await _sql.Ado.CommandFluent("asf.fn_get_other_info")
      .CommandType(CommandType.StoredProcedure)
      .CommandTimeout(60)
      .WithParameter("in_info_type", info_type)
      .WithParameter("in_info_name", info_name)
      .QueryAsync<OtherInfo>();

  }

}
