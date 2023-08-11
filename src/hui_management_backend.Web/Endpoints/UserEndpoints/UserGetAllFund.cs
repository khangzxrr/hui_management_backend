using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Endpoints.FundEndpoints;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserGetAllFund : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<UserGetAllFundResponse>
{

  private readonly IRepository<Fund> _fundRepository;
  private readonly IMapper _mapper;
  private readonly IAuthorizeService _authorizeService;

  public UserGetAllFund(IRepository<Fund> fundRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _fundRepository = fundRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.User)]
  [HttpGet(UserGetAllFundRequest.Route)]
  [SwaggerOperation(
       Summary = "Get all funds of user",
       Description = "Get all funds of user",
       OperationId = "User.getAllFund",
       Tags = new[] { "UserEndpoints" }
          )
     ]
  public override async Task<ActionResult<UserGetAllFundResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var spec = new FundsByUserIdSpec(_authorizeService.UserId);

    var funds = await _fundRepository.ListAsync(spec);

    var fundRecords = funds.Select(_mapper.Map<GeneralFundRecord>);

    var response = new FundGetAllResponse(fundRecords);

    return Ok(response);
  }
}
