using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserGetFundResponse
{
  public FundRecord fund { get; set; }

  public UserGetFundResponse(FundRecord fund)
  {
    this.fund = fund;
  }
}
