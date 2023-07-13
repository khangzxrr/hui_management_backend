using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.FundEndpoints;

namespace hui_management_backend.Web.Profiles;

public class FundTakenSessionDetailProfile : Profile
{
  public FundTakenSessionDetailProfile()
  {
    AllowNullCollections = false;

    CreateMap<TakenSessionDetail, FundTakenSessionDetailRecord>();
  }
}
