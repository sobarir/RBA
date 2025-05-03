using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.UserAllowedPlant;

[HttpGet("userallowedplants/user/{user_cd}/plant/{plant_cd}"), AllowAnonymous]
public class GetUserAllowedPlantEndpoint(IUserAllowedPlantRepository repository) : Endpoint<UserAllowedPlantRequest, Domain.Entities.UserAllowedPlant>
{

  private readonly IUserAllowedPlantRepository _repository = repository;

  public override async Task HandleAsync(UserAllowedPlantRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAsync(req.user_cd, req.plant_cd);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
