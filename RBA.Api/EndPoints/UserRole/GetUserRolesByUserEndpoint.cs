using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.UserRole;

[HttpGet("userroles/user/{user_cd}/m/{month:int}"), AllowAnonymous]
public class GetUserRolesByUserEndpoint(IUserRoleRepository repository) : Endpoint<UserRoleByUserRequest, IEnumerable<Domain.Entities.UserRole>>
{

  private readonly IUserRoleRepository _repository = repository;

  public override async Task HandleAsync(UserRoleByUserRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAllAsync(req.user_cd, req.month);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
