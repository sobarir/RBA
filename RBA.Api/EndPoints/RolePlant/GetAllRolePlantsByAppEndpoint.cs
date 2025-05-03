using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.RolePlant;

[HttpGet("roleplants/app/{id}"), AllowAnonymous]
public class GetAllRolePlantsByAppEndpoint(IRolePlantRepository repository) : Endpoint<EntityRequestById, IEnumerable<Domain.Entities.RolePlant>>
{

  private readonly IRolePlantRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetAllByAppAsync(req.id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
