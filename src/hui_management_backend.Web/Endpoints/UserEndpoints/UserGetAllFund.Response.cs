using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserGetAllFundResponse
{
  public IEnumerable<GeneralFundRecord> funds { get; set; }

  public UserGetAllFundResponse(IEnumerable<GeneralFundRecord> funds)
  {
    this.funds = funds;
  }
}
