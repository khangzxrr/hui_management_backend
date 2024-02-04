using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Enums;
using hui_management_backend.Core.UserAggregate.Records;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetAllSubUserWithPaymentService : IGetAllSubUserWithPaymentService
{
  private readonly IRepository<SubUser> _subuserRepository;
  private readonly IRepository<Payment> _paymentRepository;
  private readonly IGetFundsBySubUserIdService _getFundsBySubUserIdService;

  public GetAllSubUserWithPaymentService(
    IRepository<SubUser> subuserRepository,
    IRepository<Payment> paymentRepository,
    IGetFundsBySubUserIdService getFundsBySubUserIdService)
  {
    _subuserRepository = subuserRepository;
    _paymentRepository = paymentRepository;
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
      result.Add(subuser, await GetSubUserReport(subuser, filter));
    }


    return new Result<Dictionary<SubUser, SubUserReportWithoutSubUserInfoRecord>>(result);  
  }


  public async Task<SubUserReportWithoutSubUserInfoRecord> GetSubUserReport(SubUser subUser, SubUserWithPaymentReportFilter filters)
  {
    double totalProcessingAmount =
     subUser.Payments.Where(p => p.Status == PaymentStatus.Processing).Sum(p => p.remainPayCost);

    double totalDebtAmount = subUser.Payments.Where(p => p.Status == PaymentStatus.Debting).Sum(p => p.remainPayCost);

    if (filters.getProcessingAndDebtPaymentOnly.HasValue)
    {
      return new SubUserReportWithoutSubUserInfoRecord(0,
                                                     0,
                                                     0,
                                                     totalProcessingAmount,
                                                     totalDebtAmount,
                                                     0,
                                                     0,
                                                     0);
    }



    var predictedAliveandDeadAmount = await calculateTotalPredictedAliveAndDeadAmount(subUser);


    double totalUnfinishedTakenAmount =
      subUser.Payments
      .Where(p => p.Status != PaymentStatus.Finish)
      .SelectMany(p => p.fundBills)
      .Where(fb => fb.fromSessionDetail?.type == NormalSessionType.Taken)
      .Sum(fb => fb.fromSessionDetail!.payCost);

    double totalTakenAmount =
      subUser.Payments
      .SelectMany(p => p.fundBills)
      .Where(fb => fb.fromSessionDetail?.type == NormalSessionType.Taken)
      .Sum(fb => fb.fromSessionDetail!.payCost);

    double totalOutsideDebt =
      subUser.Payments
      .SelectMany(p => p.customBills)
      .Sum(cb => cb.payCost);

    double totalAliveAmount = predictedAliveandDeadAmount.Item1;

    double totalDeadAmount = predictedAliveandDeadAmount.Item2;


    double fundRatio = totalAliveAmount - totalDeadAmount;


    return new SubUserReportWithoutSubUserInfoRecord(totalAliveAmount,
                                                     totalDeadAmount,
                                                     fundRatio,
                                                     totalProcessingAmount,
                                                     totalDebtAmount,
                                                     totalTakenAmount,
                                                     totalUnfinishedTakenAmount,
                                                     totalOutsideDebt);
  }

  private async Task<Tuple<double, double>> calculateTotalPredictedAliveAndDeadAmount(SubUser subUser)
  {
    double totalPredictedDeadAmount = 0;
    double totalAliveAmountWithoutServiceCost = 0;

    //var finishedPayments = subUser.Payments.Where(p => p.Status == PaymentStatus.Finish);

    var finishedPaymentFunds = subUser.Payments
          .Where(p => p.Status == PaymentStatus.Finish)
          .SelectMany(p => p.fundBills)
          .Select(fb => fb.fromFund)
          .GroupBy(fb => fb?.Id)
          .Select(fb => fb.First());

    //await Task.Run(() => { });


    foreach (var requestedFund in finishedPaymentFunds)
    {

      if (requestedFund == null) continue;

      var fund = await _getFundsBySubUserIdService.getFundByFundIdAndSubUserId(requestedFund.Id, subUser.Id);

      if (fund == null) continue;

      if (!fund.Sessions.Any()) continue;

      //Vốn chết = mệnh giá * tổng số kỳ còn lại * số lượng đầu chết

      var fundMembers = fund.Members.Where(m => m.subUser.Id == subUser.Id);

      int aliveMemberCount = 0;

      foreach (FundMember member in fundMembers)
      {
        bool isDead = fund.Sessions.SelectMany(s => s.normalSessionDetails).Any(sd =>
        sd.fundMember == member &&
        (sd.type == NormalSessionType.Taken || sd.type == NormalSessionType.EmergencyTaken));

        if (isDead)
        {

          int remainSessionCount = fund.Members.Count() - fund.Sessions.Count();
          totalPredictedDeadAmount += fund.FundPrice * remainSessionCount;

          int countNotPaidDeadSession = 0;

          foreach (FundSession session in fund.Sessions)
          {
            var sessionDetailOfMember = session.normalSessionDetails.Where(sd => sd.fundMember == member &&
             (sd.type == NormalSessionType.Dead ||
             sd.type == NormalSessionType.Taken ||
             sd.type == NormalSessionType.EmergencyTaken)).FirstOrDefault();

            if (sessionDetailOfMember == null) continue;

            var finishPaymentOfSessionDetailSpec = new PaymentByStatusAndNormalSessionDetailIdSpec(PaymentStatus.Finish, sessionDetailOfMember.Id);
            bool isPaid = await _paymentRepository.AnyAsync(finishPaymentOfSessionDetailSpec);

            if (!isPaid) // NOT paid
            {
              countNotPaidDeadSession++;
            }
          }

          totalPredictedDeadAmount += fund.FundPrice * countNotPaidDeadSession;

        }
        else
        {

          aliveMemberCount++;

          int countPaidSession = 0;

          foreach (FundSession session in fund.Sessions)
          {
            var sessionDetailOfMember = session.normalSessionDetails.Where(sd => sd.fundMember == member && sd.type == NormalSessionType.Alive).FirstOrDefault();

            if (sessionDetailOfMember == null) continue;

            var finishPaymentOfSessionDetailSpec = new PaymentByStatusAndNormalSessionDetailIdSpec(PaymentStatus.Finish, sessionDetailOfMember.Id);
            bool isPaid = await _paymentRepository.AnyAsync(finishPaymentOfSessionDetailSpec);

            if (isPaid)
            {
              countPaidSession++;
            }
          }

          totalAliveAmountWithoutServiceCost += fund.FundPrice * countPaidSession;
        } //end else if

      } //end member loop

      if (totalAliveAmountWithoutServiceCost > 0)
      {
        totalAliveAmountWithoutServiceCost -= fund.ServiceCost * aliveMemberCount;
      }
    } //end fund loop

    return new Tuple<double, double>(totalAliveAmountWithoutServiceCost, totalPredictedDeadAmount);
  }
}
