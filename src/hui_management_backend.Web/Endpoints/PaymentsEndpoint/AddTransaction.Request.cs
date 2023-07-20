using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class AddTransactionRequest
{
  public const string Route = "/owner/users/{userId}/payments/{paymentId}/transactions/add";

  [FromRoute]
  public int userId { get; set; }

  [FromRoute]
  public int paymentId { get; set; }

  [FromBody]
  public AddTransactionRequestBody body { get; set; } = null!;
}
