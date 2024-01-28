
using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundBySubUserIdSpec : Specification<Fund>
{
  public FundBySubUserIdSpec(int subUserId)
  {
    Query
      .Include(f => f.Members)
        .ThenInclude(m => m.subUser)
      .Include(f => f.Sessions)
    .Where(f => f.Members.Any(m => m.subUser.Id == subUserId));
  }
}
