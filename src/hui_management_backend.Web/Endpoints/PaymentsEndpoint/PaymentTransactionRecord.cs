namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public record PaymentTransactionRecord(int id, string description, double amount, DateTimeOffset createAt, string method)
{
}
