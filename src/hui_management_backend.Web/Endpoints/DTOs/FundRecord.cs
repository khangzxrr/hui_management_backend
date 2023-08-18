
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundRecord(
  int id, 
  string name, 
  int newSessionDurationDayCount, 
  int takenSessionDeliveryDayCount,
  DateTimeOffset currentSessionDurationDate,
  DateTimeOffset nextSessionDurationDate,
  DateTimeOffset currentTakenSessionDeliveryDate, 
  DateTimeOffset nextTakenSessionDeliveryDate,
  DateTimeOffset openDate, 
  DateTimeOffset endDate, 
  double fundPrice, 
  double serviceCost, 
  double lastSessionFundPrice, 
  int membersCount, 
  int sessionsCount, 
  IEnumerable<FundMemberRecord> members, 
  IEnumerable<FundSessionRecord> sessions) : GeneralFundRecord(
    id, 
    name, 
    newSessionDurationDayCount,
    takenSessionDeliveryDayCount,
    currentSessionDurationDate, 
    nextSessionDurationDate, 
    currentTakenSessionDeliveryDate, 
    nextTakenSessionDeliveryDate, 
    openDate, 
    endDate,
    fundPrice, 
    serviceCost,
    lastSessionFundPrice, 
    membersCount, 
    sessionsCount)
{
}
