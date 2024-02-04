
using Ardalis.Result;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;

namespace hui_management_backend.Core.Services;
public class AddCustomBillForTodayPaymentService : IAddCustomBillForTodayPaymentService
{

  private readonly IGetPaymentService _paymentService;
  private readonly IRepository<Payment> _paymentRepository;

  public AddCustomBillForTodayPaymentService(IGetPaymentService paymentService, IRepository<Payment> paymentRepository)
  {
    _paymentService = paymentService;
    _paymentRepository = paymentRepository;
  }

  public async Task<Result> addCustomBillForTodayPayment(int subuserId, string customBillTypeName, double amount, string description)
  {

    var todayPayment = await _paymentService.getTodayPaymentByOwnerId(subuserId);

    if (todayPayment == null )
    {
      return Result.Error(ResponseMessageConstants.TodayPaymentIsNotFound);
    }

    CustomBillType customBillType;

    if (!CustomBillType.TryFromName(customBillTypeName, out customBillType))
    {
      return Result.Error(ResponseMessageConstants.CannotParseCustomBillType);
    }

    todayPayment.AddCustomBill(new CustomBill
    {
      description = description,
      payCost = amount,
      type = customBillType
    });

    await _paymentRepository.UpdateAsync(todayPayment);

    return Result.Success();
  }
}
