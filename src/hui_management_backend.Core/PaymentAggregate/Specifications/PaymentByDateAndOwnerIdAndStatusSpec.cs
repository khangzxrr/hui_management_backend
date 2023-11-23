using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentByDateAndOwnerIdAndStatusSpec : Specification<Payment>, ISingleResultSpecification
{
  public PaymentByDateAndOwnerIdAndStatusSpec(DateTime dateTime, int ownerId, PaymentStatus paymentStatus)
  {
    Query
      .Include(p => p.Owner)
      .Include(p => p.fundBills)
      .Include(p => p.customBills)
      .Where(p => p.CreateAt.Date == dateTime.Date && p.Owner.Id == ownerId && p.Status == paymentStatus);
  }
}
