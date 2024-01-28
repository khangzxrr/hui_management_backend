
using hui_management_backend.Core.FundAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IGetFundsBySubUserIdService
{
  public Task<IEnumerable<Fund>> getFundsBySubUserId(int subUserId);
}
