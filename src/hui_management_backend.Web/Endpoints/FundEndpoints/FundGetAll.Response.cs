namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGetAllResponse
{
  public IEnumerable<FundRecord> funds { get; set; }

  public FundGetAllResponse(IEnumerable<FundRecord> funds)
  {
    this.funds = funds;
  }
}
