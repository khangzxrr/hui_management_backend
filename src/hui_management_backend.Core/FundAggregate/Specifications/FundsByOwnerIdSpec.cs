using System.Globalization;
using System.Text;
using Ardalis.Specification;
using Diacritics.Extensions;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByOwnerIdSpec : Specification<Fund>
{

  

  public FundsByOwnerIdSpec(int ownerId, int skip, int take, string? searchTerm)
  {
    Query
     .Include(f => f.Owner)
     .Include(f => f.Members)
      .ThenInclude(m => m.subUser)
     .Include(f => f.Sessions)
     .Where(f => f.Owner.Id == ownerId )
     .Search(f => f.Name, "%" + searchTerm + "%", searchTerm != null)
     .OrderBy(f => f.Id)
     .Skip(skip)
     .Take(take);
  }
}
