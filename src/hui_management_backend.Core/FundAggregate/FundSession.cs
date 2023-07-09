using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundSession : EntityBase
{
  public DateTimeOffset TakenDate { get; private set; }
  
  public readonly List<FundSessionDetail> _fundSessionDetails = new List<FundSessionDetail>();

  public IEnumerable<FundSessionDetail> FundSessionDetails => _fundSessionDetails.AsReadOnly();
}
