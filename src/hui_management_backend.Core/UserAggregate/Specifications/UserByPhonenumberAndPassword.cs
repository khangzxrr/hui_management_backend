using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class UserByPhonenumberAndPassword : Specification<User>, ISingleResultSpecification
{

  public UserByPhonenumberAndPassword(string phonenumber, string password)
  {
    Query
      .Include( u => u.SubUsers)
      .Where(u => u.PhoneNumber == phonenumber && u.Password == password);
  }
}
