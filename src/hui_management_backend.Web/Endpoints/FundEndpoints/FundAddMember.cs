using Ardalis.ApiEndpoints;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundAddMember : EndpointBaseAsync
  .WithRequest<FundAddMemberRequest>
  .WithActionResult
{

  private readonly IRepository<Fund> _fundRepository;
  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<User> _userRepository;

  public FundAddMember(IRepository<Fund> fundRepository, IAuthorizeService authorizeService, IRepository<User> userRepository)
  {
    _fundRepository = fundRepository;
    _authorizeService = authorizeService;
    _userRepository = userRepository;
  }

  [Authorize]
  [HttpGet(FundAddMemberRequest.Route)]
  [SwaggerOperation(
    Summary = "Fund add member",
    Description = "Fund add member",
    OperationId = "Fund.addMember",
    Tags = new[] { "Fund" }
    )
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] FundAddMemberRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new FundByIdAndOwnerId(request.fundId, _authorizeService.UserId);

    var fund = await _fundRepository.FirstOrDefaultAsync(spec);

    if (fund == null)
    {
      return BadRequest("FUND_NOT_FOUND");
    }

    var user = await _userRepository.GetByIdAsync(request.memberId);

    if (user == null)
    {
      return BadRequest("USER_NOT_FOUND");
    }

    FundMember fundMember = new FundMember
    {
      User = user
    };

    fund.AddMember(fundMember);

    await _fundRepository.UpdateAsync(fund);
    await _fundRepository.SaveChangesAsync();


    return Ok();
  }
}
