namespace hui_management_backend.Web.Endpoints.DTOs;

public record GeneralFundRecord(
  int id, 
  string name, 
  string fundType,
  int NewSessionDurationCount,
  int TakenSessionDeliveryCount,
  int NewSessionCreateDayOfMonth,
  DateTimeOffset NewSessionCreateHourOfDay,
  DateTimeOffset TakenSessionDeliveryHourOfDay,
  DateTimeOffset openDate,
  DateTimeOffset endDate,
  double fundPrice, 
  double serviceCost, 
  int membersCount, 
  int sessionsCount,
  IEnumerable<DateTimeOffset> newSessionCreateDates)
{
}
