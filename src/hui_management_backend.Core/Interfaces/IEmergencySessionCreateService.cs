
using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;
public interface IEmergencySessionCreateService
{
  public Task<Result> CreateEmergencySession(int[] memberIds, int fundId, int ownerId);
}
