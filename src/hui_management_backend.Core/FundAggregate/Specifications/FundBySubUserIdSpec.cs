
using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundBySubUserIdSpec : Specification<Fund>
{
  public FundBySubUserIdSpec(int fundId, int subUserId)
  {
    Query
      .Include(f => f.Members)
      .Include(f => f.Sessions)
        .ThenInclude(s => s.normalSessionDetails)
          .ThenInclude(nsd => nsd.fundMember)
            .ThenInclude(fm => fm.subUser)
    .Where(f => f.Members.Any(m => m.subUser.Id == subUserId) && f.Id == fundId);
  }
}
