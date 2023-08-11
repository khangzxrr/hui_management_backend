using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserGetPaymentsResponse
{
  public IEnumerable<PaymentRecord> PaymentRecords { get; set; }

  public UserGetPaymentsResponse(IEnumerable<PaymentRecord> paymentRecords)
  {
    PaymentRecords = paymentRecords;
  }
}
