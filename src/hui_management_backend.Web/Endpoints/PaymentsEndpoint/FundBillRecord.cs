using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public record FundBillRecord(int id, GeneralFundRecord fromFund, FundSessionRecord fromSession, FundNormalSessionDetailRecord fromSessionDetail)
{
}
