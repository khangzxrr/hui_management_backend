using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Profiles;

public class FundNormalSessionDetailProfile : Profile
{
  public FundNormalSessionDetailProfile()
  {
    AllowNullCollections = false;

    CreateMap<NormalSessionDetail, FundNormalSessionDetailRecord>()
      .ForMember(fsd => fsd.type, opt => opt.MapFrom(nsd => nsd.type.Name));
  }
}
