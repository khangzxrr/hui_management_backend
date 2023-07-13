using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Profiles;

public class FundNormalSessionDetailProfile : Profile
{
  public FundNormalSessionDetailProfile()
  {
    AllowNullCollections = false;

    CreateMap<NormalSessionDetail, FundNormalSessionDetailRecord>();
  }
}
