using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserGetFund : EndpointBaseAsync
  .WithRequest<UserGetFundRequest>
  .WithActionResult<UserGetFundResponse>
{

  private readonly IRepository<Fund> _fundRepository;
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;

  public UserGetFund(IRepository<Fund> fundRepository, IAuthorizeService authorizeService, IMapper mapper)
  {
    _fundRepository = fundRepository;
    _authorizeService = authorizeService;
    _mapper = mapper;
  }

  [Authorize(Roles = RoleNameConstants.User)]
  [HttpGet(UserGetFundRequest.Route)]
  [SwaggerOperation(
          Summary = "Get fund by id of user",
          Description = "Get fund by id of user",
          OperationId = "User.getFund",
          Tags = new[] { "UserEndpoints" }
                   )
        ]
  public override async Task<ActionResult<UserGetFundResponse>> HandleAsync([FromRoute] UserGetFundRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundDetailByIdAndContainUserSpec(request.fundId, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return NotFound();
    }

    var fundRecord = _mapper.Map<FundRecord>(fund);

    var response = new UserGetFundResponse(fundRecord);

    return Ok(response);
  }
}
