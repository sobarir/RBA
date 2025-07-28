using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;
using RBA.Api.Contracts.Requests;
using RBA.Domain.Entities;

namespace RBA.Api.EndPoints.Action;

[HttpGet("accessright/user/{user_cd}/app/{app_code}"), AllowAnonymous]
public class GetUserAccessEndpoint(IVUserAccessRepository repository) : Endpoint<UserAvailableRoleRequest, IEnumerable<V_UserAccess>>
{

  private readonly IVUserAccessRepository _repository = repository;

  public override async Task HandleAsync(UserAvailableRoleRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAllAsync(req.user_cd, req.app_code);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
