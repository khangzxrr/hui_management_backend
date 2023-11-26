namespace hui_management_backend.Web.Endpoints.DTOs;

public record PaymentRecord(
  int id,
  DateTime createAt,
  IEnumerable<PaymentTransactionRecord> paymentTransactions,
  IEnumerable<FundBillRecord> fundBills,
  IEnumerable<CustomBillRecord> customBills,
  string Status,
  double totalCost,
  double totalTransactionCost,
  double totalOwnerMustPaid,
  double totalOwnerMustTake,
  double ownerPaidTakeDiff,
  double remainPayCost
  )
{
}
