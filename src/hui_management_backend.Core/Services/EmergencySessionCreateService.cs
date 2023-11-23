
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using MediatR;

namespace hui_management_backend.Core.Services;
public class EmergencySessionCreateService : IEmergencySessionCreateService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IRepository<Fund> _fundRepository;
  private readonly IMediator _mediator;
  private readonly IFundMemberValidatorService _fundMemberValidatorService;

  public EmergencySessionCreateService(IUnitOfWork unitOfWork, IRepository<Fund> fundRepository, IMediator mediator, IFundMemberValidatorService fundMemberValidatorService)
  {
    _unitOfWork = unitOfWork;
    _fundRepository = fundRepository;
    _mediator = mediator;
    _fundMemberValidatorService = fundMemberValidatorService;
  }

  public async Task<Result> CreateEmergencySession(int[] memberIds, int fundId, int ownerId)
  {

    _unitOfWork.BeginTransaction();

    var spec = new FundDetailByIdAndOwnerIdSpec(fundId, ownerId);
    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return Result.NotFound(ResponseMessageConstants.FundNotFound);
    }

    List<FundMember> notTakenEmergencyFundYetMembers = new();

    foreach(var memberId in memberIds)
    {
      var member = fund.Members.Where(m => m.Id == memberId).FirstOrDefault();

      if (member == null)
      {
        return Result.NotFound(ResponseMessageConstants.FundMemberNotFound);
      }

      if (_fundMemberValidatorService.isMemberTakedFund(fund, member) ||
          _fundMemberValidatorService.isMemberTakedEmergencyFund(fund, member))
      {
         return Result.Error(ResponseMessageConstants.FundMemberAlreadyTakenFund);
      }

      notTakenEmergencyFundYetMembers.Add(member);
    }


    var latestSession = fund.Sessions.LastOrDefault();

    if (latestSession == null)
    {
      return Result.Error(ResponseMessageConstants.FundNotHaveSessionYet);
    }

    if (fund.isEnd())
    {
      return Result.Error(ResponseMessageConstants.FundIsEnded);
    }

    var takenSessionDetail = latestSession.normalSessionDetails.Where(sd => sd.type == NormalSessionType.Taken).FirstOrDefault();

    if (takenSessionDetail == null)
    {
      return Result.Error(ResponseMessageConstants.SessionNotHaveTakenSessionDetail);
    }

    List<NormalSessionDetail> emergencySessionDetails = new();

    foreach(var member in notTakenEmergencyFundYetMembers)
    {
      var newTakenEmergencySessionDetail = new NormalSessionDetail
      {
        fundAmount = takenSessionDetail.fundAmount,
        lossCost = takenSessionDetail.lossCost,
        predictedPrice = takenSessionDetail.predictedPrice,
        payCost = takenSessionDetail.payCost,
        fundMember = member,
        serviceCost = takenSessionDetail.serviceCost,
        type = NormalSessionType.EmergencyTaken
      };

      emergencySessionDetails.Add(newTakenEmergencySessionDetail);
      latestSession.AddNormalSessionDetail(newTakenEmergencySessionDetail);
    }

    //remember to check for other sessions (create DEAD instead)

    var newEmergencySessionAddedEvent = new NewEmergencySessionAddedEvent(fund, latestSession, emergencySessionDetails);

    await _mediator.Publish(newEmergencySessionAddedEvent);

    await _unitOfWork.SaveAndCommitAsync();

    return Result.Success();
  }
}
