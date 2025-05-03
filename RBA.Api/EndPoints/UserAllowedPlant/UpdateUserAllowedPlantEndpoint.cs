using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.UserAllowedPlant;

[HttpPut("UserAllowedPlants"), AllowAnonymous]
public class UpdateUserAllowedPlantEndpoint(IUserAllowedPlantRepository repository) : Endpoint<Domain.Entities.UserAllowedPlant>
{
  private readonly IUserAllowedPlantRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.UserAllowedPlant req, CancellationToken ct)
  {

    var succeed = await _repository.UpdateAsync(req);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    var res = await _repository.GetAsync(req.User_Cd, req.Plant_Cd);
    await SendOkAsync(res, ct);

  }
}

