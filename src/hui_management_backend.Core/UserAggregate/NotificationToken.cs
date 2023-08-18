
using Ardalis.GuardClauses;
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.UserAggregate;
public class NotificationToken : EntityBase
{
  public string Token { get; private set; }

  public NotificationToken(string token)
  {
    Token = Guard.Against.NullOrEmpty(token);
  }

}
