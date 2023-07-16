using hui_management_backend.Web.Endpoints.UserEndpoints;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public record PaymentRecord(
  int id, 
  UserRecord owner, 
  DateTimeOffset createAt, 
  IEnumerable<PaymentTransactionRecord> paymentTransactions, 
  IEnumerable<FundBillRecord> fundBills, 
  string Status)
{
}
