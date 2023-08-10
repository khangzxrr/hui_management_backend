

using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;
public interface IAddMemberFundService
{
  public Task<Result<bool>> AddMember(int fundId, int ownerId, int subUserId);
}
