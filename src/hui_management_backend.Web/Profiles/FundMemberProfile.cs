using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.FundEndpoints;
using hui_management_backend.Web.Endpoints.UserEndpoints;

namespace hui_management_backend.Web.Profiles;

public class FundMemberProfile : Profile
{
  public FundMemberProfile()
  {
    CreateMap<FundMember, FundMemberRecord>();
      
  }
}
