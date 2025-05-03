using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("userroles/role/{role_id:int}/user/{user_cd}"), AllowAnonymous]
public class GetUserRoleEndpoint(IUserRoleRepository repository) : Endpoint<UserRoleRequest, Domain.Entities.UserRole>
{

  private readonly IUserRoleRepository _repository = repository;

  public override async Task HandleAsync(UserRoleRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAsync(req.role_id, req.user_cd);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
