
namespace hui_management_backend.Core.FundAggregate.Filters;
public class FundFilter
{
  public bool? onlyDayFund {  get; set; }
  public bool? onlyMonthFund { get; set; }
  public string? searchTerm { get; set; }
  public int? bySubuserId { get; set; }
  public FundFilter(bool? onlyDayFund, bool? onlyMonthFund, string? searchTerm, int? bySubuserId)
  {
    this.onlyDayFund = onlyDayFund;
    this.onlyMonthFund = onlyMonthFund;
    this.searchTerm = searchTerm;
    this.bySubuserId = bySubuserId;
  }
}
