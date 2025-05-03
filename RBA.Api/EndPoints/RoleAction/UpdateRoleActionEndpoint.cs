using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.RoleAction;

[HttpPut("roleactions"), AllowAnonymous]
public class UpdateRoleActionEndpoint(IRoleActionRepository repository) : Endpoint<Domain.Entities.RoleAction>
{
  private readonly IRoleActionRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.RoleAction req, CancellationToken ct)
  {

    var succeed = await _repository.UpdateAsync(req);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    var res = await _repository.GetAsync(req.Role_Id, req.Action_Id);
    await SendOkAsync(res, ct);

  }
}

