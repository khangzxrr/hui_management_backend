
using Ardalis.Result;
using hui_management_backend.Core.UserAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IAuthenticationService
{
  public Task<Result<User>> Login(string phonenumber, string password);

}
