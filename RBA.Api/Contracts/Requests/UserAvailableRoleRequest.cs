namespace RBA.Api.Contracts.Requests;

public class UserAvailableRoleRequest
{
  public required string user { get; set; }

  public required string app { get; set; }

}
