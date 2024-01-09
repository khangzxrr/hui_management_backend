
using Ardalis.Result;
using hui_management_backend.Core.UserAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IGetSubUserWithPaymentByIdService
{
  public Task<Result<SubUser>> getSubUserWithPaymentById(int creatorId, int subUserId);
}
