
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundRecord(int id, string name, int newSessionDurationDayCount, DateTimeOffset nextSessionDurationDate, int takenSessionDeliveryDayCount, DateTimeOffset nextTakenSessionDeliveryDate, DateTimeOffset openDate, DateTimeOffset endDate, double fundPrice, double serviceCost, double lastSessionFundPrice, int membersCount, int sessionsCount, IEnumerable<FundMemberRecord> members, IEnumerable<FundSessionRecord> sessions) : GeneralFundRecord(id, name, newSessionDurationDayCount, nextSessionDurationDate, takenSessionDeliveryDayCount, nextTakenSessionDeliveryDate, openDate, endDate, fundPrice, serviceCost, lastSessionFundPrice, membersCount, sessionsCount)
{
}
