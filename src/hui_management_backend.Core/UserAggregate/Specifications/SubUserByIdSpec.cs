
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class SubUserByIdSpec : Specification<SubUser>, ISingleResultSpecification
{
  public SubUserByIdSpec(int id)
  {
    Query
      .Include(u => u.rootUser)
      .Where(su => su.Id == id);
  }
}
