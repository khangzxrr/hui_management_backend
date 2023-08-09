namespace hui_management_backend.Web.Endpoints.DTOs;

public record PaymentRecord(
  int id,
  DateTimeOffset createAt,
  double totalCost,
  double totalTransactionCost,
  IEnumerable<PaymentTransactionRecord> paymentTransactions,
  IEnumerable<FundBillRecord> fundBills,
  string Status)
{
}
