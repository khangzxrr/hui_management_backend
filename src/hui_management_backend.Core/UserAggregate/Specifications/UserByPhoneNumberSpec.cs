
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class UserByPhoneNumberSpec : Specification<User>, ISingleResultSpecification
{
  public UserByPhoneNumberSpec(string phoneNumber)
  {
    Query
      .Include(u => u.Payments)
      .Include(u => u.CreateBy)
      .Where(u => u.PhoneNumber == phoneNumber);
  }
}
