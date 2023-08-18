
using Ardalis.Specification;

namespace hui_management_backend.Core.UserAggregate.Specifications;
public class NotificationTokensByUserIdSpec : Specification<User>
{
  public NotificationTokensByUserIdSpec(int userId)
  {
    Query
      .Include(u => u.NotificationTokens)
      .Where(u => u.Id == userId);
  }
}
