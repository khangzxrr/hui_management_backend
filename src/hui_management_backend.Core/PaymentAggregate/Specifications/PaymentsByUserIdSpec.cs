
using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentsByUserIdSpec: Specification<Payment>
{
  public PaymentsByUserIdSpec(int userId) {
    Query
      .Include(p => p.Owner)
        .ThenInclude(o => o.rootUser)
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
          .ThenInclude(s => s!.normalSessionDetails)
            .ThenInclude(nsd => nsd.fundMember)
              .ThenInclude(fm => fm.subUser)
                .ThenInclude(su => su.rootUser)
      .Include(p => p.fundBills)
        .ThenInclude(b => b.fromSessionDetail)
          .ThenInclude(sd => sd!.fundMember)
            .ThenInclude(fm => fm.subUser)
              .ThenInclude(o => o.rootUser)
      .Where(p => p.Owner.rootUser.Id == userId)
      .AsSplitQuery();
  }
}
