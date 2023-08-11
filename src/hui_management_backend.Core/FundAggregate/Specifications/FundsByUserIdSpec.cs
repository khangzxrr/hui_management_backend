using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByUserIdSpec : Specification<Fund>
{
  public FundsByUserIdSpec(int userId, bool isArchived = false)
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
      .Where(f => f.Members.Where(fm => fm.subUser.rootUser.Id == userId).Any() && f.IsArchived == isArchived);
  }
}
