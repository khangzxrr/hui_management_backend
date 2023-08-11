
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate.Events;
public class FundUpdateEvent : DomainEventBase
{
  public double oldFundPrice { get; private set; }
  public double oldServiceCost { get; private set; }
  public Fund fund { get; private set; }

  public FundUpdateEvent(Fund fund, double oldFundPrice, double oldServicePrice)
  {
    this.fund = fund;
    this.oldFundPrice = oldFundPrice;
    this.oldServiceCost = oldServicePrice;
  }
}
