using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.AppUser;

[HttpGet("appusers"), AllowAnonymous]
public class GetAllAppUsersEndpoint(IAppUserRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.AppUser>>
{

  private readonly IAppUserRepository _repository = repository;

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
