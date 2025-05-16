using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Api.EndPoints.AD;

namespace RBA.Api.EndPoints.Action;

[HttpGet("ad/user/current"), AllowAnonymous]
public class GetADCurrentUserEndpoint(IADUserProvider provider) : EndpointWithoutRequest<string>
{

  private readonly IADUserProvider _provider = provider;

  public override async Task HandleAsync(CancellationToken ct)
  {

    var res = await _provider.CurrentDomainUser(HttpContext);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
