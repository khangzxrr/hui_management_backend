

using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;

namespace hui_management_backend.Core.Services;
public class RemoveMemberFundService : IRemoveMemberFundService
{

  private readonly IRepository<Fund> _fundRepository;

  public RemoveMemberFundService(IRepository<Fund> fundRepository)
  {
    _fundRepository = fundRepository;
  }

  public async Task<Result<bool>> RemoveMember(int fundId, int ownerId, int memberId)
  {
    var fundSpec = new FundByIdAndOwnerIdSpec(fundId, ownerId);
    var fund = await _fundRepository.FirstOrDefaultAsync(fundSpec);

    if (fund == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundNotFound);
    }


    if (fund.Sessions.Any()) {
      return Result<bool>.Error(ResponseMessageConstants.FundIsStarted);
    }


    var fundMember = fund.Members.Where(m => m.Id == memberId).FirstOrDefault();

    if (fundMember == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundMemberNotFound);
    }

    fund.RemoveMember(fundMember);

    await _fundRepository.UpdateAsync(fund);
    await _fundRepository.SaveChangesAsync();

    return new Result<bool>(true);
  }
}
