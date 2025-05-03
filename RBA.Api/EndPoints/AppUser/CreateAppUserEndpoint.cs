using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.AppUser;

[HttpPost("appusers"), AllowAnonymous]
public class CreateAppUserEndpoint(IAppUserRepository repository) : Endpoint<Domain.Entities.AppUser>
{
  private readonly IAppUserRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.AppUser req, CancellationToken ct)
  {

    await _repository.CreateAsync(req);
    var res = await _repository.GetAsync(req.User_Cd);
    await SendCreatedAtAsync<GetAppUserEndpoint>(
      new { res!.User_Cd }, res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

