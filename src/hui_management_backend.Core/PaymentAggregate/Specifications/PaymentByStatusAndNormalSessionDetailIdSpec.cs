
using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentByStatusAndNormalSessionDetailIdSpec : Specification<Payment>
{
  public PaymentByStatusAndNormalSessionDetailIdSpec(PaymentStatus status, int normalSessionDetailId)
  {
    Query
      .Include(p => p.fundBills)
        .ThenInclude(fb => fb.fromSessionDetail)
      .Where(p => p.Status == status && p.fundBills.Any(fb => fb.fromSessionDetail!.Id == normalSessionDetailId));
  }
}
