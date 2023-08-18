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
      .ForMember(dst => dst.newSessionDurationDayCount, opt => opt.MapFrom(src => src.NewSessionDurationDayCount))
      .ForMember(dst => dst.nextSessionDurationDate, opt => opt.MapFrom(src => src.CurrentSessionDurationDate))
      .ForMember(dst => dst.takenSessionDeliveryDayCount, opt => opt.MapFrom(src => src.TakenSessionDeliveryDayCount))
      .ForMember(dst => dst.nextTakenSessionDeliveryDate, opt => opt.MapFrom(src => src.CurrentTakenSessionDeliveryDate));


  }
}
