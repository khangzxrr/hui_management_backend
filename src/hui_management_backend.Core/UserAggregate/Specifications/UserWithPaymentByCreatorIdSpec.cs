
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class UserWithPaymentByCreatorIdSpec : Specification<User>
{
  public UserWithPaymentByCreatorIdSpec(int creatorId)
  {
    Query
      .Include(u => u.Payments)
        .ThenInclude(p => p.paymentTransactions)
      .Include(u => u.Payments)
        .ThenInclude(p => p.fundBills)
          .ThenInclude(fb => fb.fromSessionDetail)
      .Include(u => u.CreateBy)
      .Where(u => u.CreateBy.Where(c => c.Id == creatorId).Any());
  }
}
