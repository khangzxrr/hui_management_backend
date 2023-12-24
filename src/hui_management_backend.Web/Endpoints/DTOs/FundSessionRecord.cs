namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundSessionRecord(
  int id,
  DateTime TakenDate,
  int sessionNumber,
IEnumerable<FundNormalSessionDetailRecord> normalSessionDetails)
{
}
