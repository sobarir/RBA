using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.RoleAction;

[HttpDelete("roleactions/role/{role_id:int}/action/{action_id:int}"), AllowAnonymous]
public class DeleteRoleActionEndpoint(IRoleActionRepository repository) : Endpoint<RoleActionRequest>
{

  private readonly IRoleActionRepository _repository = repository;

  public override async Task HandleAsync(RoleActionRequest req, CancellationToken ct)
  {

    var succeed = await _repository.DeleteAsync(req.role_id, req.action_id);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendNoContentAsync(ct);

  }

}
