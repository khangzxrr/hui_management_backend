using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.ManageUserEndpoints;

public class ReportAll : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<ReportAllResponse>
{

  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<Fund> _fundRepository;
  private readonly IRepository<User> _userRepository;
  private readonly IMapper _mapper;

  public ReportAll(IAuthorizeService authorizeService, IRepository<Fund> fundRepository, IRepository<User> userRepository, IMapper mapper)
  {
    _authorizeService = authorizeService;
    _fundRepository = fundRepository;
    _userRepository = userRepository;
    _mapper = mapper;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(ReportAllRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all user reports",
    Description = "Get all user reports",
    OperationId = "Users.getAllReport",
    Tags = new[] { "Users" }
    )
  ]
  public override async Task<ActionResult<ReportAllResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var userByCreatorIdSpec = new UserByCreatorIdSpec(_authorizeService.UserId);
    var users = await _userRepository.ListAsync(userByCreatorIdSpec);

    if (users == null) {
      return BadRequest();
    }


    List<UserReport> userReports = new List<UserReport>();

    foreach (var user in users)
    {
      var spec = new FundByOwnerAndMemberSpec(_authorizeService.UserId, user.Id);
      var funds = await _fundRepository.ListAsync(spec);

      //fund => sessions => normalSessionDetails 

      double fundRatio = 0;

      foreach (var fund in funds)
      {
        foreach (var session in fund.Sessions)
        {
          foreach (var sessionDetail in session.normalSessionDetails)
          {
            if (sessionDetail.fundMember.User != user)
            {
              continue;
            }


            if (sessionDetail.type == NormalSessionType.Alive)
            {
              fundRatio += sessionDetail.payCost;
            }
            else
            {
              fundRatio -= sessionDetail.payCost;
            }
          }

        }
      }

      var userReportRecord = _mapper.Map<UserReport>(user);
      userReportRecord.fundRatio = fundRatio;

      userReports.Add(userReportRecord);

    }


    var resposne = new ReportAllResponse(userReports);

    return Ok(resposne);
  }
}
