
using Ardalis.Result;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Enums;

namespace hui_management_backend.Core.Interfaces;
public interface IGetAllSubUserWithPaymentService
{
  public Task<Result<IEnumerable<SubUser>>> GetAllSubUserWithPayment(int ownerId, int skip, int take, string? searchTerm, SubUserWithPaymentReportFilter filter);
}
