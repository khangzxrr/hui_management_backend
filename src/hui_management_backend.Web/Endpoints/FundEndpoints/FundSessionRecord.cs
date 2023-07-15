
namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record FundSessionRecord(
  int id, 
  DateTimeOffset TakenDate, 
  int sessionNumber,
  FundTakenSessionDetailRecord takenSessionDetail,
IEnumerable<FundNormalSessionDetailRecord> normalSessionDetails)
{
}
