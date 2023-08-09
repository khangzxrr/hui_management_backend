namespace hui_management_backend.Web.Endpoints.DTOs;

public record GeneralFundRecord(int id, string name, string openDateText, DateTimeOffset openDate, double fundPrice, double serviceCost, int membersCount, int sessionsCount)
{
}
