using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class AddCustomBillRequest
{
  public const string Route = "/owner/subusers/{subuserId}/payments/custom-bills/add";

  [FromRoute]
  public int subuserId { get; set; }

  [FromBody]
  public AddCustomBillRequestBody body { get; set; } = null!;

}
