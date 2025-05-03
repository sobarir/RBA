using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.UserAllowedPlant;

[HttpGet("userallowedplants"), AllowAnonymous]
public class GetAllUserAllowedPlantsEndpoint(IUserAllowedPlantRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.UserAllowedPlant>>
{

  private readonly IUserAllowedPlantRepository _repository = repository;

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
