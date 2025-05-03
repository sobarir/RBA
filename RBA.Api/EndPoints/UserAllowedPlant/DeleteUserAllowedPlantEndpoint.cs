using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.UserAllowedPlant;

[HttpDelete("userallowedplants/user/{user_cd}/plant/{plant_cd}"), AllowAnonymous]
public class DeleteUserAllowedPlantEndpoint(IUserAllowedPlantRepository repository) : Endpoint<UserAllowedPlantRequest>
{

  private readonly IUserAllowedPlantRepository _repository = repository;

  public override async Task HandleAsync(UserAllowedPlantRequest req, CancellationToken ct)
  {

    var succeed = await _repository.DeleteAsync(req.user_cd, req.plant_cd);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendNoContentAsync(ct);

  }

}
