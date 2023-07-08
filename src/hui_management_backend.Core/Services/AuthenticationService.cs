using Ardalis.Result;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Records;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class AuthenticationService : IAuthenticationService
{

  private readonly IRepository<User> _userRepository;

  public AuthenticationService(IRepository<User> userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<Result<User>> Login(string phonenumber, string password)
  {
    var spec = new UserByPhonenumberAndPassword(phonenumber, password);
    var user = await _userRepository.FirstOrDefaultAsync(spec);

    if (user == null)
    {
      return Result.NotFound();
    }

    return user;
  }
}
