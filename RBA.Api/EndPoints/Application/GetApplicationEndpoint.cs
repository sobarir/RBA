using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.Application;

[HttpGet("applications/{id}"), AllowAnonymous]
public class GetApplicationEndpoint(IApplicationRepository repository) : Endpoint<EntityRequestById, Domain.Entities.Application>
{

  private readonly IApplicationRepository _repository = repository;

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
