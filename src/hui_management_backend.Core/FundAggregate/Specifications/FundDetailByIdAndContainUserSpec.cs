
using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundDetailByIdAndContainUserSpec : Specification<Fund>, ISingleResultSpecification
{
  public FundDetailByIdAndContainUserSpec(int fundId, int userId)
  {
    Query
     .Include(f => f.Owner)
     .Include(f => f.Members)
      .ThenInclude(m => m.subUser)
        .ThenInclude(su => su.rootUser)
     .Include(f => f.Sessions)
      .ThenInclude(s => s.normalSessionDetails)
        .ThenInclude(nsd => nsd.fundMember)
          .ThenInclude(fm => fm.subUser)
            .ThenInclude(su => su.rootUser)
     .Where(f => f.Members.Any(m => m.subUser.rootUser.Id == userId) && f.Id == fundId);
  }
}
