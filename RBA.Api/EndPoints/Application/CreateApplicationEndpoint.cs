using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Application;

[HttpPost("applications"), AllowAnonymous]
public class CreateApplicationEndpoint(IApplicationRepository repository) : Endpoint<Domain.Entities.Application>
{
  private readonly IApplicationRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.Application req, CancellationToken ct)
  {

    await _repository.CreateAsync(req);
    var res = await _repository.GetAsync(req.Application_Cd);
    await SendCreatedAtAsync<GetApplicationEndpoint>(
      new { res!.Application_Cd }, res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

