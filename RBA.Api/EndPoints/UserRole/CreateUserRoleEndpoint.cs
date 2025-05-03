using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.UserRole;

[HttpPost("userroles"), AllowAnonymous]
public class CreateUserRoleEndpoint(IUserRoleRepository repository) : Endpoint<Domain.Entities.UserRole>
{
  private readonly IUserRoleRepository _repository = repository;

  public override async Task HandleAsync(Domain.Entities.UserRole req, CancellationToken ct)
  {

    var res = await _repository.CreateAsync(req);
    res = await _repository.GetAsync(res.Role_Id, res.User_Cd);
    await SendCreatedAtAsync<GetUserRoleEndpoint>(
      new UserRoleRequest { role_id = res.Role_Id, user_cd = res.User_Cd },
        res, generateAbsoluteUrl: true, cancellation: ct
    );

  }
}

