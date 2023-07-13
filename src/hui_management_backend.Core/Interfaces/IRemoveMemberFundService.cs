using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;
public interface IRemoveMemberFundService
{
  public Task<Result<bool>> RemoveMember(int fundId, int ownerId, int memberId);
}
