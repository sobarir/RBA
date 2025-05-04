namespace RBA.Api.EndPoints.AD;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

public class ADUserMiddleware
{

  private readonly RequestDelegate next;

  public ADUserMiddleware(RequestDelegate next)
  {
    this.next = next;
  }

  public async Task Invoke(HttpContext context, IADUserProvider userProvider, IConfiguration config)
  {
    if (!(userProvider.Initialized))
    {
      await userProvider.Create(context, config);
    }
    await next(context);
  }

}
