using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class GetUserPayments : EndpointBaseAsync
  .WithRequest<GetUserPaymentsRequest>
  .WithActionResult
{

  private readonly IMapper _mapper;
  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<Payment> _paymentRepository;
  private readonly IRepository<Fund> _fundRepository;

  public GetUserPayments(IRepository<Payment> paymentRepository, IAuthorizeService authorizeService, IRepository<Fund> fundRepository, IMapper mapper)
  {
    _paymentRepository = paymentRepository;
    _authorizeService = authorizeService;
    _fundRepository = fundRepository;
    _mapper = mapper;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(GetUserPaymentsRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all user payments",
    Description = "Get all user payments",
    OperationId = "Payment.getAllPayments",
    Tags = new[] { "Payment" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetUserPaymentsRequest request, CancellationToken cancellationToken = default)
  {
    var fundSpec = new FundsByUserIdOwnerIdSpec(request.userId, _authorizeService.UserId);
    var isExistFundContainUser = await _fundRepository.AnyAsync(fundSpec);

    if (!isExistFundContainUser)
    {
      List<PaymentRecord> emptyRecords = new();
      return Ok(new GetUserPaymentsResponse(emptyRecords));
    }

    var paymentSpec = new PaymentsByUserIdSpec(request.userId);
    var payments = await _paymentRepository.ListAsync(paymentSpec);

    IEnumerable<Payment> filteredPayments = payments;

    if (request.filerByDate != null)
    {
      filteredPayments = filteredPayments.Where(p => p.CreateAt.Date == request.filerByDate.Value.Date);
    }

    if (request.filterByProcessingOrDebting != null)
    {
      filteredPayments = filteredPayments.Where(p => p.Status != PaymentStatus.Finish);
    }



    var paymentRecords = payments.Select(_mapper.Map<PaymentRecord>);
    var response = new GetUserPaymentsResponse(paymentRecords);

    return Ok(response);

  }
}
