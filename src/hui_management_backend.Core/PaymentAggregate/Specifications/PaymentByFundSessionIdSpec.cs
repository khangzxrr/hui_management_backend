using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentByFundSessionIdSpec : Specification<Payment>
{

  public PaymentByFundSessionIdSpec(int fundSesionId)
  {
    Query
      .Include(p => p.customBills)
      .Include(p => p.fundBills)
        .ThenInclude(fb => fb.fromSession)
       .Include(p => p.fundBills)
        .ThenInclude(fb => fb.fromSessionDetail)
      .Where(p => p.fundBills.Where(fb => fb.fromSession!.Id == fundSesionId).Any());
  }
}
