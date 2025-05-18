using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("userrolesinfo/user/{user}"), AllowAnonymous]
public class GetUserAvailableRoleEndpoint(IVUserRolePlantRepository repository) : Endpoint<EntityRequestById, IEnumerable<Domain.Entities.V_UserAvailableRole>>
{

  private readonly IVUserRolePlantRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetAllUserAvailableRolesAsync(req.id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
