using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpPost("actions"), AllowAnonymous]
public class CreateActionEndpoint(IActionRepository repository) : Endpoint<Domain.Entities.Action>
{
  private readonly IActionRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.Action req, CancellationToken ct)
  {
    await _repository.CreateAsync(req);
    var res = await _repository.GetAsync(req.Action_Id);
    await SendCreatedAtAsync<GetActionEndpoint>(
      new { res!.Action_Id }, res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

