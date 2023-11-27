
using Ardalis.Result;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;

namespace hui_management_backend.Core.Services;
public class CreateFinalSettlementForDeadSessionService : ICreateFinalSettlementForDeadSessionService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IRepository<Fund> _fundRepository;
  private readonly IRepository<Payment> _paymentRepository;
  private readonly IGetPaymentService _getPaymentService; 

  public CreateFinalSettlementForDeadSessionService(IUnitOfWork unitOfWork, IRepository<Fund> fundRepository, IGetPaymentService getPaymentService, IRepository<Payment> paymentRepository)
  {
    _unitOfWork = unitOfWork;
    _fundRepository = fundRepository;
    _getPaymentService = getPaymentService;
    _paymentRepository = paymentRepository;
  }

  public async Task<Result> createFinalSettlement(int fundId, int ownerId, int memberId)
  {
    _unitOfWork.BeginTransaction();

    var spec = new FundDetailByIdAndOwnerIdSpec(fundId, ownerId);
    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return Result.NotFound(ResponseMessageConstants.FundNotFound);
    }

    if (fund.Members.Count() == 0)
    {
      return Result.Error(ResponseMessageConstants.FundIsNotContainAnyUser);
    }

    if (fund.isEnd())
    {
      return Result.Error(ResponseMessageConstants.FundIsEnded);
    }

    var member = fund.Members.Where(m => m.Id == memberId).FirstOrDefault();

    if (member == null)
    {
      return Result.Error(ResponseMessageConstants.FundMemberNotFound);
    }


    var payment = await _getPaymentService.GetPaymentByDateAndOwnerId(DateTime.UtcNow, member.subUser);

    if (payment == null)
    {
      return Result.Error(ResponseMessageConstants.PaymentNotFound);
    }

    double totalDeadSessionPaycost = (fund.Members.Count() - fund.Sessions.Count()) * fund.FundPrice;

    payment.AddCustomBill(new CustomBill
    {
      description = InfoMessageConstants.FinalSettlementForDeadSessionDescription,
      payCost = totalDeadSessionPaycost,
      type = CustomBillType.OwnerTake
    });

    member.setFinalSettlementForDeadSessionBill(payment);

    await _paymentRepository.SaveChangesAsync();
    
    await _unitOfWork.SaveAndCommitAsync();

    return Result.Success();
  }
}
