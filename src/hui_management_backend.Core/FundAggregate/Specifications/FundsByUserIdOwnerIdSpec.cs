using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByUserIdOwnerIdSpec : Specification<Fund>
{
  public FundsByUserIdOwnerIdSpec(int userId, int ownerId)
  {
    Query
      .Include(f => f.Owner)
      .Include(f => f.Members)
        .ThenInclude(fm => fm.User)
      .Include(f => f.Sessions)
      .Where(f => f.Owner.Id == ownerId && f.Members.Where(fm => fm.User.Id == userId).Any());
  }
}
