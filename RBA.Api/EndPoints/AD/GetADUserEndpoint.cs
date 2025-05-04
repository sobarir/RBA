using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.Contracts;
using RBA.Api.EndPoints.AD;
using RBA.Domain.AD;

namespace RBA.Api.EndPoints.Action;

[HttpGet("ad/user/{id}"), AllowAnonymous]
public class GetADUserEndpoint(IADUserProvider provider) : Endpoint<EntityRequestById, ADUser>
{

  private readonly IADUserProvider _provider = provider;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var res = await _provider.GetADUser(req.id);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
