using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public record FundBillRecord(int id, GeneralFundRecord fromFund, double Amount)
{
}
