using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpGet("roleplants"), AllowAnonymous]
public class GetAllRolePlantEndpoint(IRolePlantRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.RolePlant>>
{

  private readonly IRolePlantRepository _repository = repository;

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
