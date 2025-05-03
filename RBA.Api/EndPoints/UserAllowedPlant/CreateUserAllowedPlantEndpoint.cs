using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.UserAllowedPlant;

[HttpPost("userallowedplants"), AllowAnonymous]
public class CreateUserAllowedPlantEndpoint(IUserAllowedPlantRepository repository) : Endpoint<Domain.Entities.UserAllowedPlant>
{
  private readonly IUserAllowedPlantRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.UserAllowedPlant req, CancellationToken ct)
  {

    var res = await _repository.CreateAsync(req);
    res = await _repository.GetAsync(res.User_Cd, res.Plant_Cd);
    await SendCreatedAtAsync<GetUserAllowedPlantEndpoint>(
      new UserAllowedPlantRequest { user_cd = res.User_Cd, plant_cd = res.Plant_Cd },
        res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

