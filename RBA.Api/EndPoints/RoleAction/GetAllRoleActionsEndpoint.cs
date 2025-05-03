using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.RoleAction;

[HttpGet("roleactions"), AllowAnonymous]
public class GetAllRoleActionsEndpoint(IRoleActionRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.RoleAction>>
{

  private readonly IRoleActionRepository _repository = repository;

  public override async Task HandleAsync(CancellationToken ct)
  {

    var res = await _repository.GetAllAsync();

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
