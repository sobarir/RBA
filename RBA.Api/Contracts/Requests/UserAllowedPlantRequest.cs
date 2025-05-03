namespace RBA.Api.Contracts.Requests;

public class UserAllowedPlantRequest
{
  public required string user_cd{ get; set; }

  public required string plant_cd { get; set; }

}
