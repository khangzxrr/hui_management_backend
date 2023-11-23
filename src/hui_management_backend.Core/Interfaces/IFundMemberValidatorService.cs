
using hui_management_backend.Core.FundAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IFundMemberValidatorService
{
  public bool isMemberTakedEmergencyFund(Fund fund, FundMember fundMember);
  public bool isMemberTakedFund(Fund fund, FundMember fundMember);
}
