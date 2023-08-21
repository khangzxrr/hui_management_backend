using AutoMapper;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Profiles;

public class FundProfile : Profile
{
  public FundProfile()
  {

    AllowNullCollections = false;

    CreateMap<Fund, FundRecord>();

    CreateMap<Fund, GeneralFundRecord>()
      .ForMember(dst => dst.fundType, opt => opt.MapFrom(src => src.FundType.Name));


  }
}
