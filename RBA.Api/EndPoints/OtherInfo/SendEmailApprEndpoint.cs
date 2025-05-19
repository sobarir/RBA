using Microsoft.AspNetCore.Authorization;

using FastEndpoints;

using RBA.Repository;
using RBA.Api.Contracts;

namespace RBA.Api.EndPoints.Action;

[HttpPost("actions"), AllowAnonymous]
public class SendEmailApprEndpoint(IUserRoleRepository repository) : Endpoint<EntityRequestById>
{
  private readonly IUserRoleRepository _repository = repository;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    //ToDo: Send Email

    var entity = await _repository.GetByIdAsync(Convert.ToInt32(req.id));
    entity.Approval_Status = "sent to approver";

    var succeed = await _repository.UpdateAsync(entity);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(entity, ct);

  }
}

