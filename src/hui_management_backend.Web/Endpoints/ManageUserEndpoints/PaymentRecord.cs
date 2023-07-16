using hui_management_backend.Web.Endpoints.UserEndpoints;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public record PaymentRecord(int id, UserRecord owner, DateTimeOffset CreateAt, IEnumerable<PaymentTransactionRecord> paymentTransactions, IEnumerable<FundBillRecord> fundBills)
{
}
