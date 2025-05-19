using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts.Requests;

namespace RBA.Api.EndPoints.Action;

[HttpGet("info/type/{info_type}/name/{info_name}"), AllowAnonymous]
public class GetAllOtherInfoEndpoint(IOtherInfoRepository repository) : Endpoint<OtherInfoRequest, IEnumerable<Domain.Entities.OtherInfo>>
{

  private readonly IOtherInfoRepository _repository = repository;

  public override async Task HandleAsync(OtherInfoRequest req, CancellationToken ct)
  {

    var res = await _repository.GetAllAsync(req.info_type, req.info_name);

    if (res is null)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(res, ct);

  }

}
