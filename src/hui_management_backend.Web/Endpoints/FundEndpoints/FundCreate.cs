using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundCreate : EndpointBaseAsync
  .WithRequest<FundCreateRequest>
  .WithActionResult<FundCreateResponse>
{

  private readonly IRepository<Fund> _fundRepository;
  
  private readonly IRepository<User> _userRepository;
  private readonly IAuthorizeService _authoizeService;
  private readonly IMapper _mapper;

  public FundCreate(IRepository<Fund> fundRepository, IRepository<User> userRepository,IMapper mapper, IAuthorizeService authorizeService)
  {
    _fundRepository = fundRepository;
    _userRepository = userRepository;
    _mapper = mapper;
    _authoizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPost(FundCreateRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund create",
    Description = "Fund create",
    OperationId = "Fund.create",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult<FundCreateResponse>> HandleAsync([FromBody] FundCreateRequest request, CancellationToken cancellationToken = default)
  {
    var user = await _userRepository.GetByIdAsync(_authoizeService.UserId);

    if (user == null)
    {
      return BadRequest();
    }


    var fund = new Fund(request.name, request.openDateText, request.openDate, request.fundPrice, request.serviceCost);
    fund.SetOwner(user);

    await _fundRepository.AddAsync(fund);
    await _fundRepository.SaveChangesAsync();

    var fundRecord = _mapper.Map<FundRecord>(fund);

    var response = new FundCreateResponse(fundRecord);

    return Ok(response);
  }
}
