using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate.Events;
public class NewEmergencySessionAddedEvent : DomainEventBase
{
  public Fund fund { get; set; }
  public FundSession fundSession { get; set; }

  public List<NormalSessionDetail> emergencyTakenSessionDetails { get; set; }

  public NewEmergencySessionAddedEvent(Fund fund, FundSession fundSession, List<NormalSessionDetail> emergencyTakenSessionDetails)
  {
    this.fund = fund;
    this.fundSession = fundSession;
    this.emergencyTakenSessionDetails = emergencyTakenSessionDetails;
  }
}
