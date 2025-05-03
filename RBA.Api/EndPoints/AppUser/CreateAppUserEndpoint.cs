using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.AppUser;

[HttpPost("usermes"), AllowAnonymous]
public class CreateAppUserEndpoint(IUserMesRepository repository) : Endpoint<Domain.Entities.UserMes>
{
  private readonly IUserMesRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.UserMes req, CancellationToken ct)
  {

    await _repository.CreateAsync(req);
    var res = await _repository.GetAsync(req.User_Cd);
    await SendCreatedAtAsync<GetAppUserEndpoint>(
      new { res!.User_Cd }, res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

