
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.PaymentAggregate;
public class FundBill : EntityBase
{
  public Fund? fromFund { get; set; }

  public FundSession? fromSession { get; set; }

  public NormalSessionDetail? fromSessionDetail { get; set; }


}
