using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class AddTransaction : EndpointBaseAsync
  .WithRequest<AddTransactionRequest>
  .WithActionResult
{

  private IRepository<Payment> _paymentRepository;
  private readonly IAuthorizeService _authorizeService;
  private readonly IUnitOfWork _unitOfWork;
  private IMediator _mediator;

  public AddTransaction(IRepository<Payment> paymentRepository, IMediator mediator, IAuthorizeService authorizeService, IUnitOfWork unitOfWork)
  {
    _paymentRepository = paymentRepository;
    _mediator = mediator;
    _authorizeService = authorizeService;
    _unitOfWork = unitOfWork;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPost(AddTransactionRequest.Route)]
  [SwaggerOperation(
    Summary = "Add new transaction for payment",
    Description = "Add new transaction for payment",
    OperationId = "Payment.getAllPayments",
    Tags = new[] { "Payment" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] AddTransactionRequest request, CancellationToken cancellationToken = default)
  {
    var paymentSpec = new PaymentsByUserIdSpec(request.userId);
    var payment = await _paymentRepository.FirstOrDefaultAsync(paymentSpec);

    if (payment == null)
    {
      return NotFound(ResponseMessageConstants.PaymentNotFound);
    }

    if (payment.Id != request.paymentId)
    {
      return BadRequest(ResponseMessageConstants.PaymentIsNotBelongToUser);
    }


    if (payment.Status == PaymentStatus.Finish)
    {
      return BadRequest(ResponseMessageConstants.PaymentIsFinished);
    }

    TransactionMethod transactionMethod;

    var isSuccessParsedTransactionMethod = TransactionMethod.TryFromName(request.body.transactionMethod, out transactionMethod);

    if (!isSuccessParsedTransactionMethod) {
      return BadRequest(ResponseMessageConstants.TransactionMethodCannotBeParsed);
    }

    if (payment.fundBills.First().fromFund.Owner.Id != _authorizeService.UserId)
    {
      return BadRequest(ResponseMessageConstants.UserIsNotBelongToFundOwner);
    }


    _unitOfWork.BeginTransaction();

    var transaction = new PaymentTransaction(request.body.transactionNote, request.body.transactionAmount, transactionMethod);
    payment.AddPaymentTransaction(transaction);

    foreach(var ev in transaction.DomainEvents)
    {
      await _mediator.Publish(ev);
    }

    await _unitOfWork.SaveAndCommitAsync();

    return Ok();
  }
}
