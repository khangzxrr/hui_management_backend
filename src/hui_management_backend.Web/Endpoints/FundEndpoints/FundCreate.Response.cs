namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundCreateResponse
{
  public FundRecord fund { get; set; }

  public FundCreateResponse(FundRecord fund)
  {
    this.fund = fund;
  }
}
