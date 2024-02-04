
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetPaymentService : IGetPaymentService
{

  private readonly IRepository<Payment> _paymentRepository;
  private readonly IRepository<SubUser> _subUserRepository;

  public GetPaymentService(IRepository<Payment> paymentRepository, IRepository<SubUser> subUserRepository)
  {
    _paymentRepository = paymentRepository;
    _subUserRepository = subUserRepository;
  }

  public async Task<Payment?> GetPaymentByDateAndOwnerId(DateTime dateTime, int subUserId)
  {
    var subUser = await _subUserRepository.GetByIdAsync(subUserId);

    if (subUser == null)
    {
      return null;
    }

    var spec = new PaymentByDateAndOwnerIdAndStatusSpec(dateTime, subUserId, PaymentStatus.Processing);

    var payment = await _paymentRepository.FirstOrDefaultAsync(spec);

    if (payment == null)
    {
      payment = new Payment
      {
        CreateAt = dateTime,
        Owner = subUser,
        Status = PaymentStatus.Processing,
      };

      await _paymentRepository.AddAsync(payment);
    }

    return payment;
  }

  public async Task<Payment?> getTodayPaymentByOwnerId(int subUserId)
  {
    return await GetPaymentByDateAndOwnerId(DateTime.UtcNow, subUserId);
  }
}
