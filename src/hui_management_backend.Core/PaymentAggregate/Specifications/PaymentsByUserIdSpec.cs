
using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentsByUserIdSpec: Specification<Payment>
{
  public PaymentsByUserIdSpec(int userId) {
    Query
      .Include(p => p.Owner)
      .Include(p => p.customBills)
      .Include(p => p.paymentTransactions)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromFund)
          .ThenInclude(f => f!.Members)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromFund)
          .ThenInclude(b => b!.Owner)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromSession)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromSessionDetail)
          .ThenInclude(sd => sd!.fundMember)
            .ThenInclude(fm => fm.subUser)
      .Where(p => p.Owner.rootUser.Id == userId);
  }
}
