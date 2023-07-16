using AutoMapper;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Web.Endpoints.PaymentsEndpoint;

namespace hui_management_backend.Web.Profiles;

public class PaymentProfile : Profile
{
  public PaymentProfile()
  {
    AllowNullCollections = false;

    CreateMap<FundBill, FundBillRecord>()
      .ForMember(r => r.status, opt => opt.MapFrom(s => s.Status.Name))
      .ForMember(r => r.type, opt => opt.MapFrom(s => s.Type.Name));

    CreateMap<PaymentTransaction, PaymentTransactionRecord>()
       .ForMember(r => r.method, opt => opt.MapFrom(s => s.Method.Name));
    CreateMap<Payment, PaymentRecord>()
        .ForMember(r => r.Status, opt => opt.MapFrom(s => s.Status.Name));

  }
}
