using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.AppUser;

[HttpGet("usermes"), AllowAnonymous]
public class GetAllAppUsersEndpoint(IUserMesRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.UserMes>>
{

  private readonly IUserMesRepository _repository = repository;

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
