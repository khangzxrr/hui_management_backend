using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByOwnerIdSpec : Specification<Fund>
{
  public FundsByOwnerIdSpec(int ownerId)
  {
    Query
      .Include(f => f.Owner)
      .Include(f => f.Members)
      .Include(f => f.Sessions)
      .Where(f => f.Owner.Id == ownerId);
  }
}
