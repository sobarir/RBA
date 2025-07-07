using Microsoft.AspNetCore.Authorization;

using FastEndpoints;
using MailKit.Net.Smtp;
using MimeKit;

using RBA.Api.Contracts;
using RBA.Domain.Entities;
using RBA.Repository;

namespace RBA.Api.EndPoints.Action;

[HttpPost("emailtoapprover"), AllowAnonymous]
public class SendEmailApprEndpoint(
  IUserRoleRepository repository,
  IOtherInfoRepository repositoryOI,
  IWebHostEnvironment hostingEnvironment
) : Endpoint<EntityRequestById>
{

  private readonly IUserRoleRepository _repository = repository;
  private readonly IOtherInfoRepository _repositoryOI = repositoryOI;
  private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;

  public override async Task HandleAsync(EntityRequestById req, CancellationToken ct)
  {

    var allInfo = await _repositoryOI.GetAllInfoByIdAsync(Convert.ToInt32(req.id));
    var smtpInfo = await _repositoryOI.GetSMTPInfoAsync();

    SendEmail(allInfo, smtpInfo);

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

  private void SendEmail(V_UserRoleAllInfo allInfo, IEnumerable<OtherInfo> smtpInfo)
  {
    string body = PopulateBody(allInfo);

    var message = new MimeMessage();

    var requestor = $"{allInfo.Requester_First_Name} {allInfo.Requester_Last_Name}";
    message.From.Add(new MailboxAddress(requestor, allInfo.Requester_Email));

    var approver = $"{allInfo.Approver_First_Name} {allInfo.Approver_Last_Name}";
    message.To.Add(new MailboxAddress(approver, allInfo.Approver_Email));
    message.Subject = "How you doin'?";

    BodyBuilder builder = new()
    {
      HtmlBody = body
    };
    message.Body = builder.ToMessageBody();

    using var client = new SmtpClient();
    var smtpServer = smtpInfo.Where(a => a.Info_Name == "smtp_server").FirstOrDefault()?.Info_Value1;
    var smtpPort = Convert.ToInt32(smtpInfo.Where(a => a.Info_Name == "smtp_port").FirstOrDefault()?.Info_Value1);
    var smtpUId = smtpInfo.Where(a => a.Info_Name == "smtp_login").FirstOrDefault()?.Info_Value1;
    var smtpPwd = smtpInfo.Where(a => a.Info_Name == "smtp_loginpwd").FirstOrDefault()?.Info_Value1;

    client.Connect(smtpServer, smtpPort, false);

    client.Authenticate(smtpUId, smtpPwd);

    client.Send(message);
    client.Disconnect(true);
  }

  private string PopulateBody(V_UserRoleAllInfo allInfo)
  {

    string contentRootPath = _hostingEnvironment.ContentRootPath;
    string emailPath = Path.Combine(contentRootPath, "Email");

    string body = string.Empty;
    using (StreamReader reader = new($"{emailPath}/email_to_approver.html"))
    {
      body = reader.ReadToEnd();
    }

    body = body.Replace("{request_by}", allInfo.Request_By);

    var requestor = $"{allInfo.Requester_First_Name} {allInfo.Requester_Last_Name}";
    body = body.Replace("{requestor}", requestor);

    body = body.Replace("{plant_cd}", allInfo.Plant_Cd);
    body = body.Replace("{application_cd}", allInfo.Application_Cd);
    body = body.Replace("{app_desc}", allInfo.App_Desc);
    body = body.Replace("{role_name}", allInfo.Role_Name);
    body = body.Replace("{description}", allInfo.Description);
    body = body.Replace("{request_justification}", allInfo.Request_Justification);
    body = body.Replace("{created_date}", DateTime.Now.ToString("dd-MMM-yyyy"));

    return body;
  }

}

