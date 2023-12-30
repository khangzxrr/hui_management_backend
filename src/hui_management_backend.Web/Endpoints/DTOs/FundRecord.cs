namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundRecord(
  int id, 
  string name,
  string fundType,
  int NewSessionDurationCount,
  int TakenSessionDeliveryCount,
  int NewSessionCreateDayOfMonth,
  DateTime NewSessionCreateHourOfDay,
  DateTime TakenSessionDeliveryHourOfDay,
  DateTime openDate,
  DateTime endDate,
  double fundPrice, 
  double serviceCost, 
  int membersCount, 
  int sessionsCount, 
  IEnumerable<FundMemberRecord> members, 
  IEnumerable<FundSessionRecord> sessions,
  IEnumerable<DateTime> newSessionCreateDates
  ) : GeneralFundRecord(
    id, 
    name,
    fundType,
    NewSessionDurationCount,
    TakenSessionDeliveryCount,
    NewSessionCreateDayOfMonth,
    NewSessionCreateHourOfDay,
    TakenSessionDeliveryHourOfDay,
    openDate,
    endDate,
    fundPrice, 
    serviceCost,
    membersCount, 
    sessionsCount,
    newSessionCreateDates)
{
}
