

using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentByFundIdSpec : Specification<Payment>
{
  public PaymentByFundIdSpec(int fundId)
  {
    Query
      .Include(p => p.fundBills)
        .ThenInclude(fb => fb.fromFund)
      .Where(p => p.fundBills.Any(fb => fb.fromFund!.Id == fundId));
    }
}
