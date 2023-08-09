
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetPaymentService : IGetPaymentService
{

  private readonly IRepository<Payment> _paymentRepository;

  public GetPaymentService(IRepository<Payment> paymentRepository)
  {
    _paymentRepository = paymentRepository;
  }

  public async Task<Payment> GetPaymentByDateAndOwnerId(DateTimeOffset dateTimeOffset, SubUser owner)
  {
    var spec = new PaymentByDateAndOwnerIdAndStatusSpec(dateTimeOffset, owner.Id, PaymentStatus.Processing);

    var payment = await _paymentRepository.FirstOrDefaultAsync(spec);

    if (payment == null)
    {
      payment = new Payment
      {
        CreateAt = dateTimeOffset,
        Owner = owner,
        Status = PaymentStatus.Processing
      };

      await _paymentRepository.AddAsync(payment);
    }


    return payment;
  }
}
