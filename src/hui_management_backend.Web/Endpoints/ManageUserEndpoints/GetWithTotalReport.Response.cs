using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetWithTotalReportResponse
{
  public SubUserReportRecord subUserReportRecord { get; }

  public GetWithTotalReportResponse(SubUserReportRecord subUserReportRecord)
  {
    this.subUserReportRecord = subUserReportRecord;
  }
}
