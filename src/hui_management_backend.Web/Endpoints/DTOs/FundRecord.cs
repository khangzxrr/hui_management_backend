
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundRecord(
  int id, 
  string name,
  string fundType,
  int NewSessionDurationCount,
  int TakenSessionDeliveryCount,
  int NewSessionCreateDayOfMonth,
  DateTimeOffset NewSessionCreateHourOfDay,
  DateTimeOffset openDate,
  DateTimeOffset endDate,
  double fundPrice, 
  double serviceCost, 
  int membersCount, 
  int sessionsCount, 
  IEnumerable<FundMemberRecord> members, 
  IEnumerable<FundSessionRecord> sessions,
  IEnumerable<DateTimeOffset> newSessionCreateDates
  ) : GeneralFundRecord(
    id, 
    name,
    fundType,
    NewSessionDurationCount,
    TakenSessionDeliveryCount,
    NewSessionCreateDayOfMonth,
    NewSessionCreateHourOfDay,
    openDate,
    endDate,
    fundPrice, 
    serviceCost,
    membersCount, 
    sessionsCount,
    newSessionCreateDates)
{
}
