using Ardalis.ApiEndpoints;
using Ardalis.Result.AspNetCore;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class AddCustomBill : EndpointBaseAsync
  .WithRequest<AddCustomBillRequest>
  .WithActionResult
{

  private readonly IAddCustomBillForTodayPaymentService _addCustomBillForTodayPaymentService;

  public AddCustomBill(IAddCustomBillForTodayPaymentService addCustomBillForTodayPaymentService)
  {
    _addCustomBillForTodayPaymentService = addCustomBillForTodayPaymentService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPost(AddCustomBillRequest.Route)]
  [SwaggerOperation(
    Summary = "Add new custom-bill for today-payment",
    Description = "Add new custom-bill for today-payment",
    OperationId = "Payment.addCustomBill",
    Tags = new[] { "Payment" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] AddCustomBillRequest request, CancellationToken cancellationToken = default)
  {

    var result = await _addCustomBillForTodayPaymentService.addCustomBillForTodayPayment(request.subuserId, request.body.customBillType, request.body.amount, request.body.description);

    if (result.IsSuccess)
    {
      return Ok();
    }

    return BadRequest(result.Errors);
  }
}
