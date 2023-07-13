
using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;
public interface IAddSessionFundService
{
  public Task<Result<bool>> AddSession(int fundId, int ownerId, int memberId, double predictedPrice);
}
