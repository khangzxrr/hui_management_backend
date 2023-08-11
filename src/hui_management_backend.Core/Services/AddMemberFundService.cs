
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;

namespace hui_management_backend.Core.Services;
public class AddMemberFundService : IAddMemberFundService
{

  private readonly IRepository<SubUser> _subUserRepository;
  private readonly IRepository<Fund> _fundRepository;

  public AddMemberFundService(IRepository<Fund> fundRepository, IRepository<SubUser> subuserRepository)
  {
    _fundRepository = fundRepository;
    _subUserRepository = subuserRepository;
  }

  public async Task<Result<bool>> AddMember(int fundId, int ownerId, int subUserId)
  {


    var fundSpec = new FundByIdAndOwnerIdSpec(fundId, ownerId);
    var fund = await _fundRepository.FirstOrDefaultAsync(fundSpec); 

    if (fund == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundNotFound);
    }

    var subUserSpec = new SubUserByIdSpec(subUserId);
    var subUser = await _subUserRepository.FirstOrDefaultAsync(subUserSpec);


    if (subUser == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.SubUserIsNotFound);
    }


    var totalExistFundMember = fund.Members.Where(m => m.subUser == subUser).Count();


    

    var fundMember = new FundMember
    {
      replicationCount = totalExistFundMember + 1,
      subUser = subUser,
    };

    fund.AddMember(fundMember);

    await _fundRepository.UpdateAsync(fund);
    await _fundRepository.SaveChangesAsync();

    return new Result<bool>(true);
  }
}
