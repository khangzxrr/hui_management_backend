using Ardalis.SmartEnum;

namespace hui_management_backend.Core.FundAggregate;
public class FundType : SmartEnum<FundType>
{
  public static FundType DayFund = new(nameof(DayFund), 0);
  public static FundType MonthFund = new(nameof(MonthFund), 1);

  public FundType(string name, int value) : base(name, value) { }
}
