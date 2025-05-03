using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.RoleAction;

[HttpGet("roleactions/role/{role_id:int}/action/{action_id:int}"), AllowAnonymous]
public class GetRoleActionEndpoint(IRoleActionRepository repository) : Endpoint<RoleActionRequest, Domain.Entities.RoleAction>
{

  private readonly IRoleActionRepository _repository = repository;

  public override async Task HandleAsync(RoleActionRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAsync(req.role_id, req.action_id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
