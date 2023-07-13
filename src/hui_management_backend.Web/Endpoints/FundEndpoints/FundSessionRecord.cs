using hui_management_backend.Core.FundAggregate;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record FundSessionRecord(int id, DateTimeOffset TakenDate, IEnumerable<FundSessionDetail> FundSessionDetails)
{
}
