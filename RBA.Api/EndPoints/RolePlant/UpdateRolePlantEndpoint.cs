using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.RolePlant;

[HttpPut("roleplants"), AllowAnonymous]
public class UpdateRolePlantEndpoint(IRolePlantRepository repository) : Endpoint<Domain.Entities.RolePlant>
{
  private readonly IRolePlantRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.RolePlant req, CancellationToken ct)
  {

    var succeed = await _repository.UpdateAsync(req);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    var res = await _repository.GetAsync(req.Role_Id);
    await SendOkAsync(res, ct);

  }
}

