
using Ardalis.Result;
using hui_management_backend.Core.PaymentAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IAddCustomBillForTodayPaymentService
{
  public Task<Result> addCustomBillForTodayPayment(int subuserId, string customBillTypeName, double amount, string description);
}
