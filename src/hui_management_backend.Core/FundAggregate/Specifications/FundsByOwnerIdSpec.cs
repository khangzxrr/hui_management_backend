using Ardalis.Specification;
using hui_management_backend.Core.FundAggregate.Filters;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByOwnerIdSpec : Specification<Fund>
{

  

  public FundsByOwnerIdSpec(int ownerId, int skip, int take, FundFilter filter)
  {
    Query
     .Include(f => f.Owner)
     .Include(f => f.Members)
      .ThenInclude(m => m.subUser)
     .Include(f => f.Sessions)
     .Where(f => f.Owner.Id == ownerId )
     .Search(f => f.Name, "%" + filter.searchTerm + "%", filter.searchTerm != null)
     .Where(f => f.FundType == FundType.DayFund, filter.onlyDayFund.HasValue)
     .Where(f => f.FundType == FundType.MonthFund, filter.onlyMonthFund.HasValue)
     .OrderBy(f => f.Id)
     .Skip(skip)
     .Take(take);
  }
}
