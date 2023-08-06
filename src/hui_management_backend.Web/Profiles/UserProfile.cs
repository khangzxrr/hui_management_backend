using AutoMapper;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Web.Endpoints.PaymentsEndpoint;
using hui_management_backend.Web.Endpoints.UserEndpoints;

namespace hui_management_backend.Web.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserRecord>();
    CreateMap<User, UserReport>()
      .ForMember(r => r.fundRatio, opt => opt.Ignore())
      .ForMember(r => r.totalTransactionCost, opt => opt.Ignore())
      .ForMember(r => r.totalCost, opt => opt.Ignore());

  }
  
}
