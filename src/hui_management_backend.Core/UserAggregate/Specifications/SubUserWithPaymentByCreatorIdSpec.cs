
using Ardalis.Specification;
using hui_management_backend.Core.UserAggregate.Enums;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class SubUserWithPaymentByCreatorIdSpec : Specification<SubUser>
{
  public SubUserWithPaymentByCreatorIdSpec(int creatorId, int skip, int take, string? searchTerm, IEnumerable<SubUserWithPaymentReportFilter.Filter> filters)
  {
    Query
      .Include(su => su.createBy)
      .Include(su => su.rootUser)
      .Include(u => u.Payments)
        .ThenInclude(p => p.paymentTransactions)
      .Include(u => u.Payments)
        .ThenInclude(p => p.fundBills)
          .ThenInclude(fb => fb.fromSessionDetail)
      .Where(su => su.createBy.Id == creatorId && su.rootUser.Id != creatorId)
      .Where(su => su.Payments.Any(p => p.fundBills.Any()), filters.Contains(SubUserWithPaymentReportFilter.Filter.AtLeastOnePayment))
      .Where(su => su.Payments.Any(p => p.CreateAt.Date == DateTime.UtcNow.Date), filters.Contains(SubUserWithPaymentReportFilter.Filter.TodayPayment))
      .Search(su => su.Name, "%" + searchTerm + "%", searchTerm != null);
      //.OrderBy(su => su.Name)
      //.Skip(skip)
      //.Take(take);
      
  }
}
