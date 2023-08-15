namespace hui_management_backend.Web.Endpoints.DTOs;

public record GeneralFundRecord(int id, string name, int newSessionDurationDayCount, int takenSessionDeliveryDayCount, DateTimeOffset openDate, double fundPrice, double serviceCost, int membersCount, int sessionsCount)
{
}
