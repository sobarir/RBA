using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.RolePlant;

[HttpGet("roleplants/{id:int}"), AllowAnonymous]
public class GetRolePlantEndpoint(IRolePlantRepository repository) : Endpoint<EntityRequestById, Domain.Entities.RolePlant>
{

  private readonly IRolePlantRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetAsync(req.id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
