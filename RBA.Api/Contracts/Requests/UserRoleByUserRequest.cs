namespace RBA.Api.Contracts.Requests;

public class UserRoleByUserRequest
{
  public required string user_cd { get; set; }

  public required int month { get; set; }

}
