using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpGet("actions"), AllowAnonymous]
public class GetAllActionsEndpoint(IActionRepository repository) : EndpointWithoutRequest<IEnumerable<Domain.Entities.Action>>
{

  private readonly IActionRepository _repository = repository;

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
