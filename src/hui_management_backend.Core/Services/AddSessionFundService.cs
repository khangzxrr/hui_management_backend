
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

  public async Task<Result<bool>> AddSession(int fundId, int ownerId, int memberId, double predictedPrice)
  {
    _unitOfWork.BeginTransaction();

    var spec = new FundDetailByIdAndOwnerIdSpec(fundId, ownerId);
    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundNotFound);
    }

    var fundMember = fund.Members.Where(m => m.Id == memberId).FirstOrDefault();

    if (fundMember == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundMemberNotFound);
    }

    //check if member was taken fund already
    if (fund.Sessions
      .Where(
        session => session.takenSessionDetail.fundMember == fundMember).Any())
    {
      return Result<bool>.Error(ResponseMessageConstants.FundMemberAlreadyTakenFund);
    }

    var sessionNumber = fund.Sessions.Count() + 1;

   

    double normalMemberPayCost = fund.FundPrice - predictedPrice;

    double fundAmount = (fund.Members.Count() - 1) * normalMemberPayCost;

    double remainCost = fundAmount - fund.ServiceCost;

    var takenSessionDetail = new TakenSessionDetail(predictedPrice, fundAmount, remainCost, fund.ServiceCost);
    takenSessionDetail.SetFundMember(fundMember);


    var newSession = new FundSession
    {
      sessionNumber = sessionNumber,
      takenDate = DateTimeOffset.UtcNow,
      takenSessionDetail = takenSessionDetail
    };


    foreach (FundMember member in fund.Members)
    {
      if (member == fundMember) continue;

      var normalSessionDetail = new NormalSessionDetail
      {
        fundMember = member,
        payCost = normalMemberPayCost
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
