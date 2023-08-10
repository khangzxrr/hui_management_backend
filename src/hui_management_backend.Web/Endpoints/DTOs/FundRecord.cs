using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundRecord(int id, string name, string openDateText, DateTimeOffset openDate, double fundPrice, double serviceCost, int membersCount, int sessionsCount, IEnumerable<FundMemberRecord> members, IEnumerable<FundSessionRecord> sessions)
{
}
