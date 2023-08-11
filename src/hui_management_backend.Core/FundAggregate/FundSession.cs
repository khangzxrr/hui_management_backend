using Ardalis.GuardClauses;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundSession : EntityBase
{
  public required DateTimeOffset takenDate { get; set; } 
  public required int sessionNumber { get; set; }

  private readonly List<NormalSessionDetail> _normalSessionDetails = new List<NormalSessionDetail>();

  public IEnumerable<NormalSessionDetail> normalSessionDetails => _normalSessionDetails.AsReadOnly();


  public void AddNormalSessionDetail(NormalSessionDetail detail)
  {
    Guard.Against.Null(detail);

    _normalSessionDetails.Add(detail);
  }

}
