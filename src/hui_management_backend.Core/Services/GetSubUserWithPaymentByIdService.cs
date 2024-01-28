
using Ardalis.Result;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;

namespace hui_management_backend.Core.Services;
public class GetSubUserWithPaymentByIdService : IGetSubUserWithPaymentByIdService
{

  private readonly IRepository<SubUser> _subuserRepository;

  public GetSubUserWithPaymentByIdService(IRepository<SubUser> subuserRepository)
  {
    _subuserRepository = subuserRepository;
  }

  public async Task<Result<SubUser>> getSubUserWithPaymentById(int creatorId, int subUserId)
  {
    var spec = new SubUserWithPaymentByCreatorIdAndSubUserIdSpec(creatorId, subUserId);
    var subuser = await _subuserRepository.FirstOrDefaultAsync(spec);

    if (subuser == null)
    {
      return Result.Error(ResponseMessageConstants.SubUserIsNotFound);
    }

    return Result.Success(subuser);
  }
}
