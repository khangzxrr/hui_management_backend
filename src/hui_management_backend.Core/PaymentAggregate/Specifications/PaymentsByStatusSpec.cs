
using Ardalis.Specification;

namespace hui_management_backend.Core.PaymentAggregate.Specifications;
public class PaymentsByStatusSpec : Specification<Payment>
{
  public PaymentsByStatusSpec(PaymentStatus status)
  {
    Query
      .Where(p => p.Status == status);
  }
}
