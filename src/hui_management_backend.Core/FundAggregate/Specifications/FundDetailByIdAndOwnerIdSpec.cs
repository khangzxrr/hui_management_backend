
using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundDetailByIdAndOwnerIdSpec : Specification<Fund>, ISingleResultSpecification
{
  public FundDetailByIdAndOwnerIdSpec(int fundId, int ownerId)
  {
    Query
     .Include(f => f.Owner)
     .Include(f => f.Members)
      .ThenInclude(m => m.User)
     .Include(f => f.Sessions)
      .ThenInclude(s => s.takenSessionDetail)
        .ThenInclude(ts => ts.fundMember)
     .Include(f => f.Sessions)
      .ThenInclude(s => s.normalSessionDetails)
     .Where(f => f.Owner.Id == ownerId && f.Id == fundId);
  }
}
