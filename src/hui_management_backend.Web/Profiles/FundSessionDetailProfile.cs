using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Profiles;

public class FundSessionDetailProfile : Profile
{
  public FundSessionDetailProfile()
  {
    AllowNullCollections = false;

    CreateMap<FundSessionDetail, FundSessionDetailRecord>();
  }
}
