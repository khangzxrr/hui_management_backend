namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGetResponse
{
  public FundRecord fund { get; set; }

  public FundGetResponse(FundRecord fund)
  {
    this.fund = fund;
  }
}
