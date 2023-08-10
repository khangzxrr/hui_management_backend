using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByOwnerIdSpec : Specification<Fund>
{
  public FundsByOwnerIdSpec(int ownerId, bool isArchived = false)
  {
    Query
      .Include(f => f.Owner)
      .Include(f => f.Members)
        .ThenInclude(m => m.subUser)
      .Include(f => f.Sessions)
        .ThenInclude(s => s.normalSessionDetails)
          .ThenInclude(nsd => nsd.fundMember)
            .ThenInclude(fm => fm.subUser)
      .Where(f => f.Owner.Id == ownerId && f.IsArchived == isArchived);
  }
}
