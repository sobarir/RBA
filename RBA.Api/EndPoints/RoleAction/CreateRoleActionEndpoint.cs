using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.RoleAction;

[HttpPost("roleactions"), AllowAnonymous]
public class CreateRoleActionEndpoint(IRoleActionRepository repository) : Endpoint<Domain.Entities.RoleAction>
{
  private readonly IRoleActionRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.RoleAction req, CancellationToken ct)
  {

    var res = await _repository.CreateAsync(req);
    res = await _repository.GetAsync(res.Role_Id, res.Action_Id);
    await SendCreatedAtAsync<GetRoleActionEndpoint>(
      new RoleActionRequest { role_id = res.Role_Id, action_id = res.Action_Id },
        res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

