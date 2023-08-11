

using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class SubUserWithPaymentByRootUserIdSpec : Specification<SubUser>
{
  public SubUserWithPaymentByRootUserIdSpec(int userId)
  {
    Query
     .Include(su => su.createBy)
     .Include(su => su.rootUser)
     .Include(u => u.Payments)
       .ThenInclude(p => p.paymentTransactions)
     .Include(u => u.Payments)
       .ThenInclude(p => p.fundBills)
        .ThenInclude(fb => fb.fromFund)
    .Include(u => u.Payments)
       .ThenInclude(p => p.fundBills)
         .ThenInclude(fb => fb.fromSessionDetail)
    .Include(u => u.Payments)
        .ThenInclude(p => p.fundBills)
          .ThenInclude(fb => fb.fromSession)
            .ThenInclude(fs => fs.normalSessionDetails)
              .ThenInclude(nsd => nsd.fundMember)
                .ThenInclude(fm => fm.subUser)
                  .ThenInclude(su => su.rootUser)
     .Where(su => su.rootUser.Id == userId);
  }
}
