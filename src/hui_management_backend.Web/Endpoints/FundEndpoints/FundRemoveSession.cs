using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Events;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Infrastructure;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundRemoveSession : EndpointBaseAsync
  .WithRequest<FundRemoveSessionRequest>
  .WithActionResult
{

  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<Fund> _fundRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMediator _mediator;

  public FundRemoveSession(IAuthorizeService authorizeService, IRepository<Fund> fundRepository, IUnitOfWork unitOfWork, IMediator mediator)
  {
    _authorizeService = authorizeService;
    _fundRepository = fundRepository;
    _unitOfWork = unitOfWork;
    _mediator = mediator;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpDelete(FundRemoveSessionRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund remove session",
    Description = "Fund remove session",
    OperationId = "Fund.removeSession",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundRemoveSessionRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundByIdAndOwnerIdSpec(request.fundId, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);
    if (fund == null)
    {
      return NotFound(ResponseMessageConstants.FundNotFound);
    }

    var session = fund.Sessions.Where(s => s.Id == request.sessionId).FirstOrDefault();

    if (session == null)
    {
      return NotFound(ResponseMessageConstants.SessionNotFound);
    }

    _unitOfWork.BeginTransaction(); 

    fund.RemoveSession(session);

    await _fundRepository.UpdateAsync(fund);

    var fundSessionDeleteEvent = new FundSessionDeleteEvent(session);
    await _mediator.Publish(fundSessionDeleteEvent);

    await _unitOfWork.SaveAndCommitAsync();   


    return Ok();
  }
}
