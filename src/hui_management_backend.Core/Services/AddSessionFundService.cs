
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;

namespace hui_management_backend.Core.Services;
public class AddSessionFundService : IAddSessionFundService
{
  private readonly IRepository<Fund> _fundRepository;

  public AddSessionFundService(IRepository<Fund> fundRepository)
  {
    _fundRepository = fundRepository;
  }

  public async Task<Result<bool>> AddSession(int fundId, int ownerId, int memberId, double predictedPrice)
  {
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

    var newSession = new FundSession();

    double normalMemberPayCost = fund.FundPrice - predictedPrice;

    double fundAmount = (fund.Members.Count() - 1) * normalMemberPayCost;

    double remainCost = fundAmount - fund.ServiceCost;

    var takenSessionDetail = new TakenSessionDetail(predictedPrice, fundAmount, remainCost, fund.ServiceCost);
    takenSessionDetail.SetFundMember(fundMember);

    newSession.SetTakenSessionDetail(takenSessionDetail);


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

    await _fundRepository.UpdateAsync(fund);
    await _fundRepository.SaveChangesAsync();

    return new Result<bool>(true);
  }
}
