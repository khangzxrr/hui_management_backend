using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentByDateAndOwnerId : Specification<Payment>, ISingleResultSpecification
{
  public PaymentByDateAndOwnerId(DateTimeOffset dateTimeOffset, int ownerId)
  {
    Query
      .Where(p => p.CreateAt.Date == dateTimeOffset.Date && p.OwnerId == ownerId);
  }
}
