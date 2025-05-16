using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.EndPoints.AD;
using RBA.Domain.AD;

namespace RBA.Api.EndPoints.Action;

[HttpGet("ad/user/current"), AllowAnonymous]
public class GetADCurrentUserEndpoint(IADUserProvider provider) : EndpointWithoutRequest<ADUser?>
{

  private readonly IADUserProvider _provider = provider;

  public override async Task HandleAsync(CancellationToken ct)
  {

    var res = await _provider.GetCurrentADUser(HttpContext);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
