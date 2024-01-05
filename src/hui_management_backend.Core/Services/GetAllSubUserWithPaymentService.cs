

using Ardalis.Result;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Enums;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetAllSubUserWithPaymentService : IGetAllSubUserWithPaymentService
{
  private readonly IRepository<SubUser> _subuserRepository;

  public GetAllSubUserWithPaymentService(IRepository<SubUser> subuserRepository)
  {
    _subuserRepository = subuserRepository;
  }

  public async Task<Result<IEnumerable<SubUser>>> GetAllSubUserWithPayment(int ownerId, int skip, int take, string? searchTerm, IEnumerable<SubUserWithPaymentReportFilter.Filter> filters)
  {

    var subuserSpec = new SubUserWithPaymentByCreatorIdSpec(ownerId, skip, take, searchTerm, filters);

    var subusers = await _subuserRepository.ListAsync(subuserSpec);

    var sortedSubUsers = subusers.OrderBy(su => su.Name.Trim().Split(' ').Last().ToLower().First());

    var filterdSubUsers = sortedSubUsers.Skip(skip).Take(take);

    return new Result<IEnumerable<SubUser>>(filterdSubUsers);  
  }
}
