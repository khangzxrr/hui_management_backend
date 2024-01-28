using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetFundByFundIdAndSubUserId : IGetFundsBySubUserIdService
{

  private IRepository<Fund> _fundRepository;

  public GetFundByFundIdAndSubUserId(IRepository<Fund> fundRepository)
  {
    _fundRepository = fundRepository;
  }

  public async Task<Fund?> getFundByFundIdAndSubUserId(int fundId, int subUserId)
  {
    var spec = new FundBySubUserIdSpec(fundId, subUserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    return fund;
  }
}
