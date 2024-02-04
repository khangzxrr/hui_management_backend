
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.UserAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IGetPaymentService
{

  public Task<Payment?> getTodayPaymentByOwnerId(int subUserId);
  public Task<Payment?> GetPaymentByDateAndOwnerId(DateTime dateTime, int subUserId);
}
