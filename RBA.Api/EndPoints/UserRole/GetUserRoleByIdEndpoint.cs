using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("userroles/transid/{id:int}"), AllowAnonymous]
public class GetUserRoleByIdEndpoint(IUserRoleRepository repository) : Endpoint<EntityRequestById, Domain.Entities.UserRole>
{

  private readonly IUserRoleRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _repository.GetByIdAsync(Convert.ToInt32(req.id));

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
