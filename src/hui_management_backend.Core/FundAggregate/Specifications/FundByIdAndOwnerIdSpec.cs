
using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundByIdAndOwnerIdSpec : Specification<Fund>, ISingleResultSpecification
{
  public FundByIdAndOwnerIdSpec(int id, int ownerId)
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
      .Where(f => f.Owner.Id == ownerId && f.Id == id);
  }
}
