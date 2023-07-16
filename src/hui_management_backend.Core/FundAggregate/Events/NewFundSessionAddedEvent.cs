
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate.Events;
public class NewFundSessionAddedEvent : DomainEventBase
{
  public Fund fund { get; set; }
  public FundSession fundSession { get; set; }

  public NewFundSessionAddedEvent(Fund fund, FundSession fundSession)
  {
    this.fund = fund;
    this.fundSession = fundSession;
  }
}
