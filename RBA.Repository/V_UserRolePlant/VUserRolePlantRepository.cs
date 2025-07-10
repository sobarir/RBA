using Microsoft.Extensions.Logging;

using RBA.Domain.Entities;

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
    var table = await _sql.Ado.CommandFluent("select * from rba.fn_get_user_available_role (@in_user_cd, @in_app_code)")
      //.CommandType(CommandType.StoredProcedure)
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

  public async Task<List<V_RequestByOwner>> GetRequestByOwnerAsync(string owner_cd)
  {
    var table = await _sql.Ado.CommandFluent("select * from rba.fn_get_request_by_owner (@in_owner_cd)")
      .CommandTimeout(60)
      .WithParameter("@in_owner_cd", owner_cd)
      .ExecuteDataTableAsync();

    var result = new List<V_RequestByOwner>();

    if (table != null)
    {
      for (int i = 0; i < table.Rows.Count; i++)
      {
        var row = table.Rows[i];

        var v = new V_RequestByOwner
        {
          Application_Cd = Convert.ToString(row["application_cd"]),
          Role_Id = Convert.ToInt32(row["role_id"]),
          Role_Name = Convert.ToString(row["role_name"]),
          Plant_Cd = Convert.ToString(row["plant_cd"]),
          Application_Owner = Convert.ToString(row["application_owner"]),
          Approval_Status = Convert.ToString(row["approval_status"]),
          Approved_By = Convert.ToString(row["approved_by"]),
          Approved_Date = Convert.ToDateTime(row["approved_date"]),
          Approver_Email = Convert.ToString(row["approver_email"]),
          Approver_First_Name = Convert.ToString(row["approver_first_name"]),
          Approver_Last_Name = Convert.ToString(row["approver_last_name"]),
          Approver_Reason = Convert.ToString(row["approver_reason"]),
          App_Desc = Convert.ToString(row["app_desc"]),
          Can_Assign = Convert.ToBoolean(row["can_assign"]),
          Can_Change_Actions = Convert.ToBoolean(row["can_change_actions"]),
          Created_Date = Convert.ToDateTime(row["created_date"]),
          Description = Convert.ToString(row["description"]),
          Expr1 = Convert.ToString(row["expr1"]),
          Is_Active = Convert.ToBoolean(row["is_cctive"]),
          Last_Edit_Date = Convert.ToDateTime(row["last_edit_date"]),
          Requester_Email = Convert.ToString(row["requester_email"]),
          Requester_First_Name = Convert.ToString(row["requester_first_name"]),
          Requester_Last_Name = Convert.ToString(row["requester_last_name"]),
          Request_By = Convert.ToString(row["request_by"]),
          Request_Justification = Convert.ToString(row["request_justification"]),
          User_Cd = Convert.ToString(row["user_cd"]),
          User_Role_Id = Convert.ToInt32(row["user_role_id"])
        };

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
