
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate.Events;
public class FundSessionDeleteEvent : DomainEventBase
{
  public FundSession fundSession { get; set; }

  public FundSessionDeleteEvent(FundSession fundSession)
  {
    this.fundSession = fundSession;
  }
}
