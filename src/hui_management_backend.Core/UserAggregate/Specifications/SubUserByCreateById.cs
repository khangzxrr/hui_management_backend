using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class SubUserByCreateById : Specification<SubUser>
{
  public SubUserByCreateById(int creatorId)
  {
    Query
      .Include(u => u.createBy)
      .Include(u => u.rootUser)
    .Where(u => u.createBy.Id == creatorId);

  }
}
