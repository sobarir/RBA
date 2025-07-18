using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.AuditTrail;

[HttpGet("audit_trail"), AllowAnonymous]
public class GetAllAuditTrailsEndpoint(IAuditTrailRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.AuditTrail>>
{

  private readonly IAuditTrailRepository _repository = repository;

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
