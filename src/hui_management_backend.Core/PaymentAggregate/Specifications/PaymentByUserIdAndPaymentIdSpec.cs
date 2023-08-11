
using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentByUserIdAndPaymentIdSpec : Specification<Payment>
{
  public PaymentByUserIdAndPaymentIdSpec(int userId, int paymentId)
  {
    Query
      .Include(p => p.Owner)
        .ThenInclude(u => u.rootUser)
      .Include(p => p.paymentTransactions)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromFund)
          .ThenInclude(f => f.Members)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromFund)
          .ThenInclude(b => b.Owner)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromSession)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromSessionDetail)
          .ThenInclude(sd => sd.fundMember)
      .Where(p => p.Owner.rootUser.Id == userId && p.Id == paymentId);
  }
}
