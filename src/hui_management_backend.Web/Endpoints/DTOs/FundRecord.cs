
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundRecord(int id, string name, int newSessionDurationDayCount, int takenSessionDeliveryDayCount, DateTimeOffset openDate, double fundPrice, double serviceCost, int membersCount, int sessionsCount, IEnumerable<FundMemberRecord> members, IEnumerable<FundSessionRecord> sessions) : GeneralFundRecord(id, name, newSessionDurationDayCount, takenSessionDeliveryDayCount, openDate, fundPrice, serviceCost, membersCount, sessionsCount)
{
}
