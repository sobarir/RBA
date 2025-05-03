using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Repository;

namespace RBA.Api.EndPoints.AppUser;

[HttpDelete("usermes/{id}"), AllowAnonymous]
public class DeleteAppUserEndpoint(IUserMesRepository repository) : Endpoint<EntityRequestById>
{

  private readonly IUserMesRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var succeed = await _repository.DeleteAsync(req.id);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendNoContentAsync(ct);

  }

}
