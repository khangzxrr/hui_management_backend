
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class UserWithPaymentSpec : Specification<User>
{
  public UserWithPaymentSpec()
  {
    Query
      .Include(u => u.Payments);
  }
}
