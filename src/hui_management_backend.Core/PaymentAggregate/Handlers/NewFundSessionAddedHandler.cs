

using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.SharedKernel.Interfaces;
using MediatR;

namespace hui_management_backend.Core.PaymentAggregate.Handlers;
public class NewFundSessionAddedHandler : INotificationHandler<NewFundSessionAddedEvent>
{

  private readonly IRepository<Payment> _repository;

  public NewFundSessionAddedHandler(IRepository<Payment> repository)
  {
    _repository = repository;
  }

  public async Task Handle(NewFundSessionAddedEvent notification, CancellationToken cancellationToken)
  {

    List<Payment> newPayments = new();

    var takenPayment = new Payment
    {
      Owner = notification.fundSession.takenSessionDetail.fundMember.User,
      Status = PaymentStatus.Processing,
      Type = PaymentType.TransferToMember,
      Amount = notification.fundSession.takenSessionDetail.remainPrice,
      CreateAt = DateTimeOffset.UtcNow
    };

    newPayments.Add(takenPayment);
     
    foreach(NormalSessionDetail normalSessionDetail in notification.fundSession.normalSessionDetails)
    {
      var toOwnerPayment = new Payment
      {
        Amount = normalSessionDetail.payCost,
        CreateAt = DateTimeOffset.UtcNow,
        Owner = normalSessionDetail.fundMember.User,
        Status = PaymentStatus.Processing,
        Type = PaymentType.TransferToOwner,
      };

      newPayments.Add(toOwnerPayment);
    }


    await _repository.AddRangeAsync(newPayments);
    await _repository.SaveChangesAsync();


  }
}
