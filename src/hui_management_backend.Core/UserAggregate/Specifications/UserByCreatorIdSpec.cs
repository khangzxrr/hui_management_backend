
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class UserByCreatorIdSpec : Specification<User>
{
  public UserByCreatorIdSpec(int creatorId)
  {
    Query
      .Include(u => u.Payments)
      .Include(u => u.CreateBy)
      .Where(u => u.CreateBy.Where(c => c.Id == creatorId).Any());
  }
}
