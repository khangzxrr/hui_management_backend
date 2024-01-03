using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class SubUserByCreateById : Specification<SubUser>
{
  public SubUserByCreateById(int creatorId, int skip, int take, string? searchTerm)
  {
    Query
      .Include(su => su.createBy)
      .Include(su => su.rootUser)
      .Where(su => su.createBy.Id == creatorId && su.rootUser.Id != creatorId)
      .Search(su => su.Name, "%" + searchTerm + "%", searchTerm != null)
      .Search(su => su.NickName, "%" + searchTerm + "%", searchTerm != null)
      .OrderBy(su => su.Name)
      .Skip(skip)
      .Take(take);
      

  }
}
