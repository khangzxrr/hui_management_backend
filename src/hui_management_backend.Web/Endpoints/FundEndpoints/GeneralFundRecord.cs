namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record GeneralFundRecord(int id, string name, string openDateText, DateTimeOffset openDate, double fundPrice, double serviceCost, int membersCount, int sessionsCount)
{
}
