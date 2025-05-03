using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Application;

[HttpPut("applications"), AllowAnonymous]
public class UpdateApplicationEndpoint(IApplicationRepository repository) : Endpoint<Domain.Entities.Application>
{
  private readonly IApplicationRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.Application req, CancellationToken ct)
  {

    var succeed = await _repository.UpdateAsync(req);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    var res = await _repository.GetAsync(req.Application_Cd);
    await SendOkAsync(res, ct);

  }
}

