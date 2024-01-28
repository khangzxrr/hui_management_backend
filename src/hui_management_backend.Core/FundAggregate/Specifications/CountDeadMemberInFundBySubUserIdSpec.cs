
using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class CountDeadMemberInFundBySubUserIdSpec : Specification<Fund>
{
  public CountDeadMemberInFundBySubUserIdSpec(int fundId, int subUserId)
  {
    Query
      .Include(f => f.Sessions)
        .ThenInclude(s => s.normalSessionDetails)
          .ThenInclude(nsd => nsd.fundMember)
            .ThenInclude(fm => fm.subUser)
      .Where(f => f.Id == fundId && f.Sessions.Any(s => s.normalSessionDetails.Any(nsd => nsd.type == NormalSessionType.Dead && nsd.fundMember.subUser.Id == subUserId)));
  }
}
