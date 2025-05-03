using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.AppUser;

[HttpPut("usermes"), AllowAnonymous]
public class UpdateAppUserEndpoint(IUserMesRepository repository) : Endpoint<Domain.Entities.UserMes>
{
  private readonly IUserMesRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.UserMes req, CancellationToken ct)
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

