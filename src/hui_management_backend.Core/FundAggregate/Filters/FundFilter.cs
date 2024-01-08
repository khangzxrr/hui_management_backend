
namespace hui_management_backend.Core.FundAggregate.Filters;
public class FundFilter
{
  public bool? onlyDayFund {  get; set; }
  public bool? onlyMonthFund { get; set; }
  public string? searchTerm { get; set; }

  public FundFilter(bool? onlyDayFund, bool? onlyMonthFund, string? searchTerm)
  {
    this.onlyDayFund = onlyDayFund;
    this.onlyMonthFund = onlyMonthFund;
    this.searchTerm = searchTerm;
  }
}
