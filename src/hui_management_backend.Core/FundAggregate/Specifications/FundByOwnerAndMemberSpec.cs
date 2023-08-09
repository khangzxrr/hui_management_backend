
using Ardalis.Specification;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundByOwnerAndMemberSpec : Specification<Fund>
{
  public FundByOwnerAndMemberSpec(int ownerId, int userId)
  {
    Query
      .Include(f => f.Owner)
      .Include(f => f.Sessions)
        .ThenInclude(s => s.normalSessionDetails)
      .Include(f => f.Members)
        .ThenInclude(m => m.subUser)
      .Where(f => f.Members.Any(m => m.subUser.Id == userId) && f.Owner.Id == ownerId);
  }
}
