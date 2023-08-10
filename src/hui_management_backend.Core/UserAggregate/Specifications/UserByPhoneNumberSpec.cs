
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class UserByPhoneNumberSpec : Specification<User>, ISingleResultSpecification
{
  public UserByPhoneNumberSpec(string phoneNumber)
  {
    Query
      .Include(u => u.SubUsers)
        .ThenInclude(s => s.Payments)
      .Include(u => u.SubUsers)
        .ThenInclude(s => s.createBy)
      .Where(u => u.PhoneNumber == phoneNumber);
  }
}
