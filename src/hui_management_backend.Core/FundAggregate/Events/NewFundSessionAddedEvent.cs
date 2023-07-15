
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate.Events;
public class NewFundSessionAddedEvent : DomainEventBase
{
  public FundSession fundSession { get; set; }

  public NewFundSessionAddedEvent(FundSession fundSession)
  {
    this.fundSession = fundSession;
  }
}
