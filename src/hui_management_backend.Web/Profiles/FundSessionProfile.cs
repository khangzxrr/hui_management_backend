using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Profiles;

public class FundSessionProfile : Profile
{
  public FundSessionProfile()
  {
    AllowNullCollections = false;

    CreateMap<FundSession, FundSessionRecord>();
  }
}
