using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("userrolesinfo/appowner/{id}"), AllowAnonymous]
public class GetRequestByOwnerEndpoint(IVUserRolePlantRepository repository) : Endpoint<EntityRequestById, IEnumerable<Domain.Entities.V_RequestByOwner>>
{

  private readonly IVUserRolePlantRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetRequestByOwnerAsync(req.id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
