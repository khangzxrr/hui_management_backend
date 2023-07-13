
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;

namespace hui_management_backend.Core.Services;
public class AddMemberFundService : IAddMemberFundService
{

  private readonly IRepository<User> _userRepository;
  private readonly IRepository<Fund> _fundRepository;

  public AddMemberFundService(IRepository<User> userRepository, IRepository<Fund> fundRepository)
  {
    _userRepository = userRepository;
    _fundRepository = fundRepository;
  }

  public async Task<Result<bool>> AddMember(int fundId, int ownerId, int userId)
  {
    var user = await _userRepository.GetByIdAsync(userId);

    if (user == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.UserNotFound);
    }

    var fundSpec = new FundByIdAndOwnerIdSpec(fundId, ownerId);
    var fund = await _fundRepository.FirstOrDefaultAsync(fundSpec); 

    if (fund == null)
    {
      return Result<bool>.NotFound(ResponseMessageConstants.FundNotFound);
    }

    var totalExistFundMember = fund.Members.Where(m => m.User == user).Count();



    var fundMember = new FundMember
    {
      NickName = $"{user.Name}-{totalExistFundMember + 1}",

      User = user,
    };

    fund.AddMember(fundMember);

    await _fundRepository.UpdateAsync(fund);
    await _fundRepository.SaveChangesAsync();

    return new Result<bool>(true);
  }
}
