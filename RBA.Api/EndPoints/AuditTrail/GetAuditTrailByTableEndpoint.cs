using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpGet("audit_trail/table/{id}"), AllowAnonymous]
public class GetAuditTrailByTableEndpoint(IAuditTrailRepository repository) : Endpoint<EntityRequestById, IEnumerable<Domain.Entities.AuditTrail>>
{

  private readonly IAuditTrailRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetAllByTableAsync(req.id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
