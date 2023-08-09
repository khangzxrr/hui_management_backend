using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByUserIdOwnerIdSpec : Specification<Fund>
{
  public FundsByUserIdOwnerIdSpec(int userId, int ownerId)
  {
    Query
      .Include(f => f.Owner)
      .Include(f => f.Members)
        .ThenInclude(fm => fm.subUser)
      .Include(f => f.Sessions)
        .ThenInclude(s => s.normalSessionDetails)
          .ThenInclude(nsd => nsd.fundMember)
             .ThenInclude(fm => fm.subUser)
      .Where(f => f.Owner.Id == ownerId && f.Members.Where(fm => fm.subUser.Id == userId).Any());
  }
}
