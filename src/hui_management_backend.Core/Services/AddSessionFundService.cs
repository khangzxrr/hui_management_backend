
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using MediatR;

namespace hui_management_backend.Core.Services;
public class AddSessionFundService : IAddSessionFundService
{

  private readonly IUnitOfWork _unitOfWork;
  private readonly IRepository<Fund> _fundRepository;
  private readonly IMediator _mediator;
  private readonly IFundMemberValidatorService _fundMemberValidatorService;

  public AddSessionFundService(IRepository<Fund> fundRepository, IMediator mediator, IUnitOfWork unitOfWork, IFundMemberValidatorService fundMemberValidatorService)
  {
    _fundRepository = fundRepository;
    _mediator = mediator;
    _unitOfWork = unitOfWork;
    _fundMemberValidatorService = fundMemberValidatorService;
  }

  public async Task<Result<bool>> AddSession(int fundId, int ownerId, int memberId, double predictedPrice)
  {
    _unitOfWork.BeginTransaction();

    var spec = new FundDetailByIdAndOwnerIdSpec(fundId, ownerId);
    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null) 
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundNotFound);
    }

    var fundTakenMember = fund.Members.Where(m => m.Id == memberId).FirstOrDefault();

    if (fundTakenMember == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundMemberNotFound);
    }

    //check if member was taken fund already
    if (_fundMemberValidatorService.isMemberTakedFund(fund, fundTakenMember))
    {
      return Result<bool>.Error(ResponseMessageConstants.FundMemberAlreadyTakenFund);
    }


    //======================

    var sessionNumber = fund.Sessions.Count() + 1;

    int deadMemberCount = fund.Sessions.Count();
    double deadMemberPayCost = deadMemberCount * fund.FundPrice;


    double aliveMemberPayCost = fund.FundPrice - predictedPrice;
    //-1 skip who taken fund
    double fundAmount = (fund.Members.Count() - deadMemberCount - 1) * aliveMemberPayCost + deadMemberPayCost;
    double lossCost = (fund.Members.Count() - 1) * fund.FundPrice - fundAmount;

    double remainCost = fundAmount - fund.ServiceCost;

    var newSession = new FundSession
    {
      sessionNumber = sessionNumber,
      takenDate = DateTime.UtcNow
    };

    var takenSessionDetail = new NormalSessionDetail {
      fundAmount = fundAmount,
      lossCost = lossCost,
      predictedPrice = predictedPrice,
      payCost = remainCost,
      serviceCost = fund.ServiceCost,
      type = NormalSessionType.Taken,
      fundMember = fundTakenMember,
    };

    /*
     * if the fund member taked an emergency fund before => generate EmergencyReceivable which owner will take which dead price instead of a normal taken 
     */
    if (_fundMemberValidatorService.isMemberTakedEmergencyFund(fund, fundTakenMember))
    {
      takenSessionDetail.type = NormalSessionType.EmergencyReceivable;
      takenSessionDetail.payCost = fund.FundPrice;
    }


    newSession.AddNormalSessionDetail(takenSessionDetail);


    foreach (FundMember member in fund.Members)
    {
      if (member == fundTakenMember) continue;

      bool isAlreadyTaken = _fundMemberValidatorService.isMemberTakedFund(fund, member);
      bool isTakedEmergencyFund = _fundMemberValidatorService.isMemberTakedEmergencyFund(fund, member);

      var normalSessionDetail = new NormalSessionDetail
      {
        fundMember = member,

        //take full price if dead, otherwise take good price

        payCost = isAlreadyTaken || isTakedEmergencyFund ? fund.FundPrice : aliveMemberPayCost,
        type = isAlreadyTaken || isTakedEmergencyFund ? NormalSessionType.Dead : NormalSessionType.Alive,
        lossCost = isAlreadyTaken || isTakedEmergencyFund ? 0 : -predictedPrice,
        fundAmount = fundAmount,
        predictedPrice = predictedPrice,
        serviceCost = fund.ServiceCost,
      };

      newSession.AddNormalSessionDetail(normalSessionDetail);
    }

    fund.AddSession(newSession);

    var domainEvent = new NewFundSessionAddedEvent(fund, newSession);
    await _mediator.Publish(domainEvent);

    await  _unitOfWork.SaveAndCommitAsync();

    return new Result<bool>(true);
  }
}
