using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.Application;

[HttpDelete("applications/{id}"), AllowAnonymous]
public class DeleteApplicationEndpoint(IApplicationRepository repository) : Endpoint<EntityRequestById>
{

  private readonly IApplicationRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var succeed = await _repository.DeleteAsync(req.id);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendNoContentAsync(ct);

  }

}
