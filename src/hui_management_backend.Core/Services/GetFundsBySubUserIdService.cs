
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetFundsBySubUserIdService : IGetFundsBySubUserIdService
{

  private IRepository<Fund> _fundRepository;

  public GetFundsBySubUserIdService(IRepository<Fund> fundRepository)
  {
    _fundRepository = fundRepository;
  }

  public async Task<IEnumerable<Fund>> getFundsBySubUserId(int subUserId)
  {
    var spec = new FundBySubUserIdSpec(subUserId);

    var funds = await _fundRepository.ListAsync(spec);

    return funds;
  }
}
