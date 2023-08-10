using AutoMapper;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<SubUser, SubUserRecord>()
      .ForMember(r => r.totalAliveAmount, opt => opt.Ignore())
      .ForMember(r => r.totalDeadAmount, opt => opt.Ignore())
      .ForMember(r => r.fundRatio, opt => opt.Ignore())
      .ForMember(r => r.totalDebtAmount, opt => opt.Ignore())
      .ForMember(r => r.totalProcessingAmount, opt => opt.Ignore())
      .ForMember(r => r.totalTakenAmount, opt => opt.Ignore());

  }
  
}
