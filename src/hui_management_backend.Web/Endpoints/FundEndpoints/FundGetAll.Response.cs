using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGetAllResponse
{
  public IEnumerable<GeneralFundRecord> funds { get; set; }

  public FundGetAllResponse(IEnumerable<GeneralFundRecord> funds)
  {
    this.funds = funds;
  }
}
