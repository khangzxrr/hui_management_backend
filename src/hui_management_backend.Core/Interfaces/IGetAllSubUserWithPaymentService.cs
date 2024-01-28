
using Ardalis.Result;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Enums;
using hui_management_backend.Core.UserAggregate.Records;

namespace hui_management_backend.Core.Interfaces;
public interface IGetAllSubUserWithPaymentService
{
  public Task<Result<Dictionary<SubUser, SubUserReportWithoutSubUserInfoRecord>>> GetAllSubUserWithPayment(int ownerId, int skip, int take, string? searchTerm, SubUserWithPaymentReportFilter filter);

  public Task<SubUserReportWithoutSubUserInfoRecord> GetSubUserReport(SubUser subUser);
}
