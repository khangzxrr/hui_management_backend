namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundUpdateResponse
{
  public FundRecord fund { get; set; }

  public FundUpdateResponse(FundRecord fund)
  {
    this.fund = fund;
  }
}
