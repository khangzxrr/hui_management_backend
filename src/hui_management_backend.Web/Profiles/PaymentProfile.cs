using AutoMapper;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Web.Endpoints.ManageUserEndpoints;

namespace hui_management_backend.Web.Profiles;

public class PaymentProfile : Profile
{
  public PaymentProfile()
  {
    AllowNullCollections = false;

    CreateMap<FundBill, FundBillRecord>();
    CreateMap<PaymentTransaction, PaymentTransactionRecord>();
    CreateMap<Payment, PaymentRecord>();

  }
}
