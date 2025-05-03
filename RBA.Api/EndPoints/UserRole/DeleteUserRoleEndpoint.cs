using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.UserRole;

[HttpDelete("userroles/role/{role_id:int}/user/{user_cd}"), AllowAnonymous]
public class DeleteUserRoleEndpoint(IUserRoleRepository repository) : Endpoint<UserRoleRequest>
{

  private readonly IUserRoleRepository _repository = repository;

  public override async Task HandleAsync(UserRoleRequest req, CancellationToken ct)
  {

    var succeed = await _repository.DeleteAsync(req.role_id, req.user_cd);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendNoContentAsync(ct);

  }

}
