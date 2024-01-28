

using System.Collections.Generic;
using Ardalis.Result;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Enums;
using hui_management_backend.Core.UserAggregate.Records;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetAllSubUserWithPaymentService : IGetAllSubUserWithPaymentService
{
  private readonly IRepository<SubUser> _subuserRepository;
  private readonly ICountDeadMemberBySubUserIdService _countDeadMemberBySubUserIdService;
  private readonly IGetFundsBySubUserIdService _getFundsBySubUserIdService;

  public GetAllSubUserWithPaymentService(IRepository<SubUser> subuserRepository, ICountDeadMemberBySubUserIdService countDeadMemberBySubUserIdService, IGetFundsBySubUserIdService getFundsBySubUserIdService)
  {
    _subuserRepository = subuserRepository;
    _countDeadMemberBySubUserIdService = countDeadMemberBySubUserIdService;
    _getFundsBySubUserIdService = getFundsBySubUserIdService;
  }

  

  public async Task<Result<Dictionary<SubUser, SubUserReportWithoutSubUserInfoRecord>>> GetAllSubUserWithPayment(int ownerId, int skip, int take, string? searchTerm, SubUserWithPaymentReportFilter filter)
  {

    var subuserSpec = new SubUserWithPaymentByCreatorIdSpec(ownerId, skip, take, searchTerm, filter);

    var subusers = await _subuserRepository.ListAsync(subuserSpec);


    var sortedSubUsers = subusers.OrderBy(su => su.Name.Trim().Split(' ').Last().ToLower().First());
    var filterdSubUsers = sortedSubUsers.Skip(skip).Take(take);

    Dictionary<SubUser, SubUserReportWithoutSubUserInfoRecord> result = new Dictionary<SubUser, SubUserReportWithoutSubUserInfoRecord>();

    foreach (var subuser in filterdSubUsers)
    {
      result.Add(subuser, await GetSubUserReport(subuser));
    }


    return new Result<Dictionary<SubUser, SubUserReportWithoutSubUserInfoRecord>>(result);  
  }

  public async Task<SubUserReportWithoutSubUserInfoRecord> GetSubUserReport(SubUser subUser)
  {

    double totalPredictedDeadAmount = 0;
    double totalAliveAmountWithoutServiceCost = 0;


    var finishedPayments = subUser.Payments.Where(p => p.Status == PaymentStatus.Finish);


    //totalPredictedDeadAmount = finishedPayments
    //  .SelectMany(p => p.fundBills)
    //  .Where(fb => fb.fromSessionDetail?.type == FundAggregate.NormalSessionType.Dead)
    //  .Sum(fb => fb.fromFund!.FundPrice * fb.fromFund!.RemainSessionCount);



    var finishedPaymentFunds = subUser.Payments
          .Where(p => p.Status == PaymentStatus.Finish)
          .SelectMany(p => p.fundBills)
          .Select(fb => fb.fromFund)
          .GroupBy(fb => fb?.Id)
          .Select(fb => fb.First());

    foreach (var requestedFund in finishedPaymentFunds)
    {

      if (requestedFund == null) continue;

      var fund = await _getFundsBySubUserIdService.getFundByFundIdAndSubUserId(requestedFund.Id, subUser.Id);

      if (fund == null) continue;

      //int deadMemberCountInSpecificFund = await _countDeadMemberBySubUserIdService.countDeadMemberBySubUserId(fund.Id, subUser.Id);
      int deadMemberCountInSpecificFund = fund.Sessions.Count() == 0 ? 0 : fund.Sessions.Last().normalSessionDetails.Count(nsd => (nsd.type == FundAggregate.NormalSessionType.Dead || 
      nsd.type == FundAggregate.NormalSessionType.Taken || 
      nsd.type == FundAggregate.NormalSessionType.EmergencyTaken) && nsd.fundMember.subUser.Id == subUser.Id); 

      int aliveMemberCountInSpecificFund = fund.Sessions.Count() == 0 ? 0 : fund.Sessions.Last().normalSessionDetails.Count(nsd => (nsd.type == FundAggregate.NormalSessionType.Alive) && nsd.fundMember.subUser.Id == subUser.Id);

      if (deadMemberCountInSpecificFund > 0)
      {
        totalPredictedDeadAmount += fund.FundPrice * (fund.Members.Count() - fund.Sessions.Count()) * deadMemberCountInSpecificFund;
      }

      if (aliveMemberCountInSpecificFund > 0)
      {
        totalAliveAmountWithoutServiceCost += fund.FundPrice * fund.Sessions.Count() * aliveMemberCountInSpecificFund - (fund.ServiceCost * aliveMemberCountInSpecificFund);
      }
      
    }



    double totalUnfinishedTakenAmount =
      subUser.Payments
      .Where(p => p.Status != PaymentStatus.Finish)
      .SelectMany(p => p.fundBills)
      .Where(fb => fb.fromSessionDetail?.type == FundAggregate.NormalSessionType.Taken)
      .Sum(fb => fb.fromSessionDetail!.payCost);

    double totalTakenAmount =
      subUser.Payments
      .SelectMany(p => p.fundBills)
      .Where(fb => fb.fromSessionDetail?.type == FundAggregate.NormalSessionType.Taken)
      .Sum(fb => fb.fromSessionDetail!.payCost);

    double totalProcessingAmount =
      subUser.Payments.Where(p => p.Status == PaymentStatus.Processing).Sum(p => p.remainPayCost);

    double totalDebtAmount = subUser.Payments.Where(p => p.Status == PaymentStatus.Debting).Sum(p => p.remainPayCost);


    double fundRatio = totalAliveAmountWithoutServiceCost - totalPredictedDeadAmount;

    double totalAliveAmount = totalAliveAmountWithoutServiceCost;

    double totalDeadAmount = totalPredictedDeadAmount;



    return new SubUserReportWithoutSubUserInfoRecord(totalAliveAmount, totalDeadAmount, fundRatio, totalProcessingAmount, totalDebtAmount, totalTakenAmount, totalUnfinishedTakenAmount);
  }
}
