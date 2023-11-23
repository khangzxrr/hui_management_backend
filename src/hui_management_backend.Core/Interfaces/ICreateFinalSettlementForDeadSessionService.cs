

using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;
public interface ICreateFinalSettlementForDeadSessionService 
{
  Task<Result> createFinalSettlement(int fundId,int ownerId, int memberId);
}
