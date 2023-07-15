using Ardalis.GuardClauses;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.FundAggregate;
public class FundSession : EntityBase
{
  public DateTimeOffset takenDate { get; private set; } 
  public int sessionNumber { get; private set; }

  public TakenSessionDetail takenSessionDetail { get; private set; } = null!;

  private List<NormalSessionDetail> _normalSessionDetails = new List<NormalSessionDetail>();

  public IEnumerable<NormalSessionDetail> normalSessionDetails => _normalSessionDetails.AsReadOnly();
  
  public FundSession(int sessionNumber)
  {
    takenDate = DateTimeOffset.Now;
    this.sessionNumber = sessionNumber;
  }

  public void SetTakenSessionDetail(TakenSessionDetail detail)
  {
    takenSessionDetail = Guard.Against.Null(detail);
  }

  public void AddNormalSessionDetail(NormalSessionDetail detail)
  {
    Guard.Against.Null(detail);

    _normalSessionDetails.Add(detail);
  }

}
