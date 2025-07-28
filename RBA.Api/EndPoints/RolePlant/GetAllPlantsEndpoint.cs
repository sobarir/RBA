using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpGet("plants"), AllowAnonymous]
public class GetAllPlantsEndpoint(IRolePlantRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.MasPlant>>
{

  private readonly IRolePlantRepository _repository = repository;

  public override async Task HandleAsync(CancellationToken ct)
  {

    var res = await _repository.GetAllPlantsAsync();

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
