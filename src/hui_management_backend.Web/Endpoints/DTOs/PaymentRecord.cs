namespace hui_management_backend.Web.Endpoints.DTOs;

public record PaymentRecord(
  int id,
  DateTime createAt,
  double totalCost,
  double totalTransactionCost,
  IEnumerable<PaymentTransactionRecord> paymentTransactions,
  IEnumerable<FundBillRecord> fundBills,
  IEnumerable<CustomBillRecord> customBills,
  string Status)
{
}
