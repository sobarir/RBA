using FastEndpoints;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using MimeKit;
using RBA.Api.Contracts;
using RBA.Domain.Entities;
using RBA.Repository;
using System.Text.RegularExpressions;

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
    var apprvInfo = await _repositoryOI.GetApprvInfoAsync();
    var emailInfo = await _repositoryOI.GetEmailInfoAsync();

    SendEmail(allInfo, smtpInfo, apprvInfo, emailInfo);

    var entity = await _repository.GetByIdAsync(Convert.ToInt32(req.id));
    entity.Email_Notification = "sent to approver";

    var succeed = await _repository.UpdateAsync(entity);

    if (!succeed)
    {
      await SendNotFoundAsync(ct);
      return;
    }

    await SendOkAsync(entity, ct);

  }

  private static string ExtractEmailName(string? email)
  {

    if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
      throw new ArgumentException("Invalid CC email address.");

    string localPart = email.Split('@')[0];
    string normalized = localPart.Replace('.', ' ');

    string[] words = normalized.Split([' '], StringSplitOptions.RemoveEmptyEntries);

    for (int i = 0; i < words.Length; i++)
    {
      var word = words[i].Trim();
      words[i] = char.ToUpper(word[0]) + word[1..].ToLower();
    }

    return string.Join(" ", words);
  }

  private void SendEmail(
    V_UserRoleAllInfo allInfo,
    IEnumerable<OtherInfo> smtpInfo,
    IEnumerable<OtherInfo> apprvInfo,
    IEnumerable<OtherInfo> emailInfo
  )
  {
    string body = PopulateBody(allInfo, apprvInfo);

    var message = new MimeMessage();

    var requestor = $"{allInfo.Requester_First_Name} {allInfo.Requester_Last_Name}";

    var requestorEmail = smtpInfo.Where(a => a.Info_Name == "emailFrom").FirstOrDefault()?.Info_Value1;
    message.From.Add(new MailboxAddress(requestor, requestorEmail));

    var approver = $"{allInfo.Approver_First_Name} {allInfo.Approver_Last_Name}";
    message.To.Add(new MailboxAddress(approver, allInfo.Approver_Email));

    var ccAddrs = emailInfo.Where(a => a.Info_Name == "emailCc");
    foreach (var ccAddr in ccAddrs)
    {
      var ccEmail = ccAddr?.Info_Value1;
      var ccName = ExtractEmailName(ccEmail);
      message.Cc.Add(new MailboxAddress(ccName, ccEmail));
    }

    var title = emailInfo.Where(a => a.Info_Name == "title").FirstOrDefault()?.Info_Value1;
    title = $"{title} {allInfo.Application_Cd?.ToUpperInvariant()}";
    message.Subject = title;

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

  private string PopulateBody(V_UserRoleAllInfo allInfo, IEnumerable<OtherInfo> apprvInfo)
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

    var apprvLink = apprvInfo.Where(a => a.Info_Name == "form_name").FirstOrDefault()?.Info_Value1;
    apprvLink = $"{apprvLink}/{allInfo.User_Role_Id}";
    body = body.Replace("{apprv_link}", apprvLink);

    return body;
  }

}

