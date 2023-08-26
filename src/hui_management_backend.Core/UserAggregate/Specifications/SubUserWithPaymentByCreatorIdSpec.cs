
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class SubUserWithPaymentByCreatorIdSpec : Specification<SubUser>
{
  public SubUserWithPaymentByCreatorIdSpec(int creatorId)
  {
    Query
      .Include(su => su.createBy)
      .Include(su => su.rootUser)
      .Include(u => u.Payments)
        .ThenInclude(p => p.paymentTransactions)
      .Include(u => u.Payments)
        .ThenInclude(p => p.fundBills)
          .ThenInclude(fb => fb.fromSessionDetail)
      .Where(su => su.createBy.Id == creatorId && su.rootUser.Id != creatorId);
  }
}
