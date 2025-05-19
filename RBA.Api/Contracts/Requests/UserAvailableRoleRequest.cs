namespace RBA.Api.Contracts.Requests;

public class UserAvailableRoleRequest
{
  public required string user_cd { get; set; }

  public required string app_code { get; set; }

}
