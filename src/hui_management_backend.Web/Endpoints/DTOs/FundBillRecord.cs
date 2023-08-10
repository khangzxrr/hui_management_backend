using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundBillRecord(int id, GeneralFundRecord fromFund, FundSessionRecord fromSession, FundNormalSessionDetailRecord fromSessionDetail)
{
}
