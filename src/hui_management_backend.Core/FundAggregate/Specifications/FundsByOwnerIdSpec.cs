using Ardalis.Specification;
using hui_management_backend.Core.FundAggregate.Filters;

namespace hui_management_backend.Core.FundAggregate.Specifications;
public class FundsByOwnerIdSpec : Specification<Fund>
{

  

  public FundsByOwnerIdSpec(int ownerId, int skip, int take, string? searchTerm, IEnumerable<FundFilter.FundFilterEnum> filters)
  {
    Query
     .Include(f => f.Owner)
     .Include(f => f.Members)
      .ThenInclude(m => m.subUser)
     .Include(f => f.Sessions)
     .Where(f => f.Owner.Id == ownerId )
     .Search(f => f.Name, "%" + searchTerm + "%", searchTerm != null)
     .Where(f => f.FundType == FundType.DayFund, filters.Contains(FundFilter.FundFilterEnum.OnlyDayFund))
     .Where(f => f.FundType == FundType.MonthFund, filters.Contains(FundFilter.FundFilterEnum.OnlyMonthFund))
     .OrderBy(f => f.Id)
     .Skip(skip)
     .Take(take);
  }
}
