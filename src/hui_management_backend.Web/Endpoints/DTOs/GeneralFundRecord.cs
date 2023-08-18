namespace hui_management_backend.Web.Endpoints.DTOs;

public record GeneralFundRecord(
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
  int sessionsCount)
{
}
