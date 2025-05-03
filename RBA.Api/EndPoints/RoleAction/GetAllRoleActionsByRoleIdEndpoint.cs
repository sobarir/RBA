using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts;

namespace RBA.Api.EndPoints.RoleAction;

[HttpGet("roleactions/role/{role_id:int}"), AllowAnonymous]
public class GetAllRoleActionsByRoleIdEndpoint(IRoleActionRepository repository) : Endpoint<EntityRequestById, IEnumerable<Domain.Entities.RoleAction>>
{

  private readonly IRoleActionRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetByRoleIdAsync(Convert.ToInt32(req.id));

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
