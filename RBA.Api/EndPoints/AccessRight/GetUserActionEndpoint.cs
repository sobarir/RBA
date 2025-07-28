using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;
using RBA.Domain.Entities;

namespace RBA.Api.EndPoints.Action;

[HttpGet("accessright/user/{user_cd}/action/{app_code}"), AllowAnonymous]
public class GetUserActionEndpoint(IVUserActionRepository repository) : Endpoint<UserAvailableRoleRequest, IEnumerable<V_UserAction>>
{

  private readonly IVUserActionRepository _repository = repository;

  public override async Task HandleAsync(UserAvailableRoleRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAllAsync(req.user_cd, Convert.ToInt32(req.app_code));

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
