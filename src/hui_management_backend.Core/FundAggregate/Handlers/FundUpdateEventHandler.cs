
using hui_management_backend.Core.FundAggregate.Events;
using MediatR;

namespace hui_management_backend.Core.FundAggregate.Handlers;
public class FundUpdateEventHandler : INotificationHandler<FundUpdateEvent>
{
  public Task Handle(FundUpdateEvent notification, CancellationToken cancellationToken)
  {
    if (notification.oldServiceCost == notification.fund.ServiceCost && 
      notification.oldFundPrice == notification.fund.FundPrice)
    {
      
    }

    throw new NotImplementedException();

    //foreach(var session in notification.fund.Sessions)
    //{
    //  var takenSessionDetail = session.normalSessionDetails.First(nsd => nsd.type == NormalSessionType.Taken);

    //  int deadFundSessionDetailCount = session.normalSessionDetails.Count(nsd => nsd.type == NormalSessionType.Dead);
    //  int aliveFundSessionDetailCount = session.normalSessionDetails.Count(nsd => nsd.type == NormalSessionType.Alive);

    //  takenSessionDetail.serviceCost = notification.fund.ServiceCost;
    //  takenSessionDetail.fundAmount = deadFundSessionDetailCount * notification.fund.FundPrice + 
    //    aliveFundSessionDetailCount * (notification.fund.FundPrice - );


    //}
  }
}
