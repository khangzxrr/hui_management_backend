
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.Interfaces;

namespace hui_management_backend.Core.Services;
public class FundMemberValidatorService : IFundMemberValidatorService
{
  public bool isMemberTakedEmergencyFund(Fund fund, FundMember fundMember)
  {
    return fund.Sessions
       .Where(
         session => session.normalSessionDetails.Where(nsd => nsd.type == NormalSessionType.EmergencyTaken && nsd.fundMember == fundMember).Any()
       ).Any();
  }

  

  public bool isMemberTakedFund(Fund fund, FundMember fundMember)
  {
    return fund.Sessions
      .Where(
        session => session.normalSessionDetails.Where(
          nsd => (nsd.type == NormalSessionType.Taken) && nsd.fundMember == fundMember).Any()
      ).Any();
  }
}
