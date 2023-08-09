using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class GetUserPaymentsResponse
{
  public IEnumerable<PaymentRecord> PaymentRecords { get; set; }

  public GetUserPaymentsResponse(IEnumerable<PaymentRecord> paymentRecords)
  {
    PaymentRecords = paymentRecords;
  }
}
