using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentByDateAndOwnerIdAndStatusSpec : Specification<Payment>, ISingleResultSpecification
{
  public PaymentByDateAndOwnerIdAndStatusSpec(DateTimeOffset dateTimeOffset, int ownerId, PaymentStatus paymentStatus)
  {
    Query
      .Include(p => p.Owner)
      .Where(p => p.CreateAt.Date == dateTimeOffset.Date && p.Owner.Id == ownerId && p.Status == paymentStatus);
  }
}
