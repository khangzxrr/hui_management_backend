
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class UserWithCreatorByIdSpec : Specification<User>, ISingleResultSpecification
{
  public UserWithCreatorByIdSpec(int id)
  {
    Query
      .Include(u => u.Payments)
      .Include(u => u.CreateBy)
      .Where(u => u.Id == id);
  }
}
