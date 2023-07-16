

using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using MediatR;

namespace hui_management_backend.Core.PaymentAggregate.Handlers;
public class NewFundSessionAddedHandler : INotificationHandler<NewFundSessionAddedEvent>
{

  private readonly IRepository<Payment> _paymentRepository;
  private readonly IGetPaymentService _getPaymentService;
  
  public NewFundSessionAddedHandler(IRepository<Payment> repository, IGetPaymentService getPaymentService)
  {
    _paymentRepository = repository;
    _getPaymentService = getPaymentService;
  }

  public async Task Handle(NewFundSessionAddedEvent notification, CancellationToken cancellationToken)
  {

    var takenPayment = await _getPaymentService.GetPaymentByDateAndOwnerId(DateTimeOffset.Now, notification.fundSession.takenSessionDetail.fundMember.User);

    var takenBill = new FundBill
    {
      Amount = notification.fundSession.takenSessionDetail.remainPrice,
      fromFund = notification.fund,
      Status = PaymentStatus.Processing,
      Type = PaymentType.TransferToMember
    };

    takenPayment.AddBill(takenBill);

    List<Payment> normalPayments = new();
     
    foreach(NormalSessionDetail normalSessionDetail in notification.fundSession.normalSessionDetails)
    {
      var normalPayment = await _getPaymentService.GetPaymentByDateAndOwnerId(DateTimeOffset.Now, normalSessionDetail.fundMember.User);

      normalPayment.AddBill(new FundBill
      {
        Amount = normalSessionDetail.payCost,
        fromFund = notification.fund,
        Status= PaymentStatus.Processing,
        Type= PaymentType.TransferToOwner
      });

      normalPayments.Add(normalPayment);
    }

    await _paymentRepository.UpdateAsync(takenPayment);
    await _paymentRepository.UpdateRangeAsync(normalPayments);

  }
}
