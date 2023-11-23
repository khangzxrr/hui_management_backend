
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class ScanExpiredProcessingPaymentService : IScanExpiredProcessingPayment
{

  private readonly IRepository<Payment> _paymentRepository;

  public ScanExpiredProcessingPaymentService(IRepository<Payment> paymentRepository)
  {
    _paymentRepository = paymentRepository;
  }

  public async Task ScanExpiredProcessingPayment()
  {
    var spec = new PaymentsByStatusSpec(PaymentStatus.Processing);
    var payments = await _paymentRepository.ListAsync(spec);

    if (payments == null)
    {
      return;
    }

    foreach (var payment in payments)
    {
      if (DateTime.UtcNow.Subtract(payment.CreateAt).TotalHours >= 12)
      {
        payment.SetStatus(PaymentStatus.Debting);
      }
    }

    await _paymentRepository.UpdateRangeAsync(payments);

    Console.WriteLine($"Updated {payments.Count} payments to debt");
  }
}
