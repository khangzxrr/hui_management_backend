
using hui_management_backend.Core.FundAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IGetFundsBySubUserIdService
{
  public Task<Fund?> getFundByFundIdAndSubUserId(int fundId, int subUserId);
}
