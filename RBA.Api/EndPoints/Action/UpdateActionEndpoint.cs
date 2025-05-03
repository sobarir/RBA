using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpPut("actions"), AllowAnonymous]
public class UpdateActionEndpoint(IActionRepository repository) : Endpoint<Domain.Entities.Action>
{
  private readonly IActionRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.Action req, CancellationToken ct)
  {

    var succeed = await _repository.UpdateAsync(req);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    var res = await _repository.GetAsync(req.Action_Id);
    await SendOkAsync(res, ct);

  }
}

