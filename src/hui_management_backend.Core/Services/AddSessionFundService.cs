
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
  public AddSessionFundService(IRepository<Fund> fundRepository, IMediator mediator, IUnitOfWork unitOfWork)
  {
    _fundRepository = fundRepository;
    _mediator = mediator;
    _unitOfWork = unitOfWork;
  }

  private bool isMemberAlreadyTakeFund(Fund fund, FundMember fundMember) { 
    return fund.Sessions
      .Where(
        session => session.normalSessionDetails.Where(nsd => nsd.type == NormalSessionType.Taken && nsd.fundMember == fundMember).Any()
      ).Any();
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
    if (isMemberAlreadyTakeFund(fund, fundTakenMember))
    {
      return Result<bool>.Error(ResponseMessageConstants.FundMemberAlreadyTakenFund);
    }

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
      takenDate = DateTimeOffset.UtcNow
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
    newSession.AddNormalSessionDetail(takenSessionDetail);



    foreach (FundMember member in fund.Members)
    {
      if (member == fundTakenMember) continue;

      bool isAlreadyTaken = isMemberAlreadyTakeFund(fund, member);

      var normalSessionDetail = new NormalSessionDetail
      {
        fundMember = member,
        //take full price if dead, otherwise take good price
        payCost = isAlreadyTaken ? fund.FundPrice : aliveMemberPayCost,
        type = isAlreadyTaken ? NormalSessionType.Dead : NormalSessionType.Alive,
        lossCost = isAlreadyTaken ? 0 : -predictedPrice,
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
