namespace RBA.Api.Contracts.Requests;

public class UserRoleRequest
{
  public required string user_cd { get; set; }

  public required int role_id { get; set; }

}
