namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddEmergencySessionRequestBody
{
  public int[] memberIds { get; set; }

  public FundAddEmergencySessionRequestBody(int[] memberIds)
  {
    this.memberIds = memberIds;
  }
}
