using AutoMapper;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Web.Endpoints.UserEndpoints;

namespace hui_management_backend.Web.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserRecord>();
  }
  
}
