using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Application;

[HttpGet("applications"), AllowAnonymous]
public class GetAllApplicationsEndpoint(IApplicationRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.Application>>
{

  private readonly IApplicationRepository _repository = repository;

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
