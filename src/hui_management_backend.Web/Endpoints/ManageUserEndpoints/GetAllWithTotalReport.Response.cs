using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class GetAllWithTotalReportResponse
{
  public IEnumerable<SubUserReportRecord> subUserReportRecords { get;  }

  public GetAllWithTotalReportResponse(IEnumerable<SubUserReportRecord> subUserReportRecords)
  {
    this.subUserReportRecords = subUserReportRecords;
  }
}
