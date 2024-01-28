
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class CountDeadMemberBySubUserIdService : ICountDeadMemberBySubUserIdService
{

  private IRepository<Fund> _fundRepository;

  public CountDeadMemberBySubUserIdService(IRepository<Fund> fundRepository)
  {
    _fundRepository = fundRepository;
  }

  public async Task<Result<int>> countDeadMemberBySubUserId(int fundId, int subUserId)
  {
    var spec = new CountDeadMemberInFundBySubUserIdSpec(fundId, subUserId);

    var count = await _fundRepository.CountAsync(spec);

    return new Result<int>(count);
  }
}
