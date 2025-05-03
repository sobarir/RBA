using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("userroles"), AllowAnonymous]
public class GetAllUserRolesEndpoint(IUserRoleRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.UserRole>>
{

  private readonly IUserRoleRepository _repository = repository;

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
