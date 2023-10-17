namespace hui_management_backend.Web.Endpoints.DTOs;

public record GeneralFundRecord(
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
  IEnumerable<DateTime> newSessionCreateDates)
{
}
