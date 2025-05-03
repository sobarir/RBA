using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;

namespace RBA.Api.EndPoints.UserRole;

[HttpPut("userroles"), AllowAnonymous]
public class UpdateUserRoleEndpoint(IUserRoleRepository repository) : Endpoint<Domain.Entities.UserRole>
{
  private readonly IUserRoleRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.UserRole req, CancellationToken ct)
  {

    var succeed = await _repository.UpdateAsync(req);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    var res = await _repository.GetAsync(req.Role_Id, req.User_Cd);
    await SendOkAsync(res, ct);

  }
}

