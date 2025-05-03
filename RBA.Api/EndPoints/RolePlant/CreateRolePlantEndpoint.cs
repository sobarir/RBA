using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.RolePlant;

[HttpPost("roleplants"), AllowAnonymous]
public class CreateRolePlantEndpoint(IRolePlantRepository repository) : Endpoint<Domain.Entities.RolePlant>
{
  private readonly IRolePlantRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.RolePlant req, CancellationToken ct)
  {
    await _repository.CreateAsync(req);
    var res = await _repository.GetAsync(req.Role_Id);
    await SendCreatedAtAsync<GetRolePlantEndpoint>(
      new { res!.Role_Id }, res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

