using AutoMapper;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Profiles;

public class PaymentProfile : Profile
{
  public PaymentProfile()
  {
    AllowNullCollections = false;

    CreateMap<FundBill, FundBillRecord>();

    CreateMap<PaymentTransaction, PaymentTransactionRecord>()
       .ForMember(r => r.method, opt => opt.MapFrom(s => s.Method.Name));
    CreateMap<Payment, PaymentRecord>()
        .ForMember(r => r.Status, opt => opt.MapFrom(s => s.Status.Name));

  }
}
