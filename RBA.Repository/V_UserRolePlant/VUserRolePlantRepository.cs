using Microsoft.Extensions.Logging;

using RBA.Domain.Entities;
using System.Data;

namespace RBA.Repository;

public class VUserRolePlantRepository(IFreeSql sql, ILogger<RepositoryBase<V_UserRolePlant>> logger) 
  : RepositoryBase<V_UserRolePlant>(sql, logger), IVUserRolePlantRepository
{

  public async Task<IEnumerable<V_UserRolePlant>> GetAllAsync(string user_cd)
  {
    return await _sql.Select<V_UserRolePlant>()
      .Where(a => a.User_Cd == user_cd)
      .ToListAsync();
  }

  public async Task<IEnumerable<V_UserRolePlant>> GetAllByIdAsync(int user_role_id)
  {
    return await _sql.Select<V_UserRolePlant>()
      .Where(a => a.User_Role_Id == user_role_id)
      .ToListAsync();
  }

  public async Task<List<V_UserAvailableRole>> GetAllUserAvailableRolesAsync(string user_cd, string app_code)
  {
    var table = await _sql.Ado.CommandFluent("asf.fn_get_user_available_role")
      .CommandType(CommandType.StoredProcedure)
      .CommandTimeout(60)
      .WithParameter("in_user_cd", user_cd)
      .WithParameter("in_app_code", app_code)
      //.QueryAsync<V_UserAvailableRole>();
      .ExecuteDataTableAsync();

    var result = new List<V_UserAvailableRole>();

    if (table != null)
    {
      for (int i = 0; i < table.Rows.Count; i++)
      {
        var v = new V_UserAvailableRole();
        var row = table.Rows[i];

        v.Application_Cd = Convert.ToString(row["application_cd"]);
        v.App_Description = Convert.ToString(row["app_description"]);
        v.Role_Id = Convert.ToInt32(row["role_id"]);
        v.Role_Name = Convert.ToString(row["role_name"]);
        v.Role_Description = Convert.ToString(row["role_description"]);
        v.Plant_Cd = Convert.ToString(row["plant_cd"]);

        result.Add(v);
      }
    }

    return result;

  }

  public override Task<bool> DeleteAsync(object? id)
  {
    throw new NotImplementedException();
  }

  public override Task<V_UserRolePlant> CreateAsync(V_UserRolePlant entity)
  {
    throw new NotImplementedException();
  }

  public override Task<bool> UpdateAsync(V_UserRolePlant entity)
  {
    throw new NotImplementedException();
  }

  public override Task<V_UserRolePlant?> GetAsync(object? id)
  {
    throw new NotImplementedException();
  }

}
