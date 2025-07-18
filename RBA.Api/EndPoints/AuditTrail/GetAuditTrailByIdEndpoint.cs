using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpGet("audit_trail/id/{id:int}"), AllowAnonymous]
public class GetAuditTrailByIdEndpoint(IAuditTrailRepository repository) : Endpoint<EntityRequestById, Domain.Entities.AuditTrail>
{

  private readonly IAuditTrailRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetJsonByIdAsync(Convert.ToInt32(req.id));

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
