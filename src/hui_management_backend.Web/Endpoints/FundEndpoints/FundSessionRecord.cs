
using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record FundSessionRecord(
  int id, 
  DateTime TakenDate, 
  int sessionNumber,
IEnumerable<FundNormalSessionDetailRecord> normalSessionDetails)
{
}
