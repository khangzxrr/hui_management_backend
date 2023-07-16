namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public record PaymentTransactionRecord(int id, string Description, double Amount, DateTimeOffset CreateAt)
{
}
