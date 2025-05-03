using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.AppUser;

[HttpPut("appusers"), AllowAnonymous]
public class UpdateAppUserEndpoint(IAppUserRepository repository) : Endpoint<Domain.Entities.AppUser>
{
  private readonly IAppUserRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.AppUser req, CancellationToken ct)
  {

    var succeed = await _repository.UpdateAsync(req);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    var res = await _repository.GetAsync(req.User_Cd);
    await SendOkAsync(res, ct);

  }
}

