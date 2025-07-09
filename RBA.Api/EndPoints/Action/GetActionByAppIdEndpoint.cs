using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpGet("actions/application/{id}"), AllowAnonymous]
public class GetActionByAppIdEndpoint(IActionRepository repository) : Endpoint<EntityRequestById, IEnumerable<Domain.Entities.Action>>
{

  private readonly IActionRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetByAppIdAsync(req.id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
