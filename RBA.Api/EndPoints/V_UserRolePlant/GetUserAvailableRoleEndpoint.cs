using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using RBA.Api.Contracts.Requests;
using RBA.Repository;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("userrolesinfo/user/{user_cd}/app/{app_code}"), AllowAnonymous]
public class GetUserAvailableRoleEndpoint(IVUserRolePlantRepository repository) : Endpoint<UserAvailableRoleRequest, IEnumerable<Domain.Entities.V_UserAvailableRole>>
{

  private readonly IVUserRolePlantRepository _repository = repository;

  public override async Task HandleAsync(UserAvailableRoleRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAllUserAvailableRolesAsync(req.user_cd, req.app_code);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
