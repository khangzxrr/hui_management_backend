
using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;
public interface ICountDeadMemberBySubUserIdService
{
  public Task<Result<int>> countDeadMemberBySubUserId(int fundId, int subUserId);
}
