using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using RBA.Repository;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("approleactions"), AllowAnonymous]
public class GetApplicationRoleActionEndpoint(IVApplicationRoleActionRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.V_ApplicationRoleAction>>
{

  private readonly IVApplicationRoleActionRepository _repository = repository;

  public override async Task HandleAsync(CancellationToken ct)
  {

    var apps = Query<string[]>("app");

    var res = await _repository.GetAllAsync(apps);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
