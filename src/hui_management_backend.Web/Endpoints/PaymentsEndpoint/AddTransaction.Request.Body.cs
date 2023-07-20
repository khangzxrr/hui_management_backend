namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class AddTransactionRequestBody
{
  public string transactionMethod { get; set; } = null!;
  public double transactionAmount { get; set; }
  public string transactionNote { get; set; } = string.Empty;
}
