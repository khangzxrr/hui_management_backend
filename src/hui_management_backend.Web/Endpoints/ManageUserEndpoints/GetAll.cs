using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAll : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult<GetAllResponse>
{
  private readonly IAuthorizeService _authorizeService;
  private readonly IMapper _mapper;
  private readonly IRepository<User> _userRepository;
  private readonly IRepository<Fund> _fundRepository;

  public GetAll(IRepository<User> userRepository, IMapper mapper, IAuthorizeService authorizeService, IRepository<Fund> fundRepository)
  {
    _userRepository = userRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
    _fundRepository = fundRepository;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(GetAllRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all users",
    Description = "Get all users",
    OperationId = "Users.getAll",
    Tags = new[] { "Users" }
    )
  ]
  public override async Task<ActionResult<GetAllResponse>> HandleAsync([FromRoute] GetAllRequest request, CancellationToken cancellationToken = default)
  {
    IEnumerable<User> users;

    var userWithPaymentSpec = new UserWithPaymentByCreatorIdSpec(_authorizeService.UserId);
    users = await _userRepository.ListAsync(userWithPaymentSpec);

    if (request.filterByAnyPayment.HasValue)
    {
      users = users.Where(u => u.Payments.Any());
    }

    if (request.filterByNotFinishedPayment.HasValue)
    {
      users = users.Where(u => u.Payments.Where(p => p.Status != PaymentStatus.Finish).Any());
    }

    var result = await _userRepository.ListAsync();

    if (result == null)
    {
      return BadRequest();
    }

    List<UserRecord> userRecords = new List<UserRecord>();

    //if (request.getFundRatio.HasValue)
    //{
    //  foreach (var user in users)
    //  {
    //    var spec = new FundByOwnerAndMemberSpec(_authorizeService.UserId, user.Id);
    //    var funds = await _fundRepository.ListAsync(spec);

    //    //fund => sessions => normalSessionDetails 

    //    double fundRatio = 0;

    //    foreach (var fund in funds)
    //    {
    //      foreach (var session in fund.Sessions)
    //      {
    //        foreach (var sessionDetail in session.normalSessionDetails)
    //        {
    //          if (sessionDetail.fundMember.User != user)
    //          {
    //            continue;
    //          }
    //          if (sessionDetail.type == NormalSessionType.Alive)
    //          {
    //            fundRatio += sessionDetail.payCost;
    //          }
    //          else
    //          {
    //            fundRatio -= sessionDetail.payCost;
    //          }
    //        }

    //      }
    //    }

    //    var userRecord = _mapper.Map<UserWithFundRatioRecord>(user, opt => opt.Items["fundRatio"] = fundRatio);
    //    userRecords.Add(userRecord);

    //  }
    //}

    var response = new GetAllResponse
    {
      Users = userRecords
    };

    return Ok(response);
  }
}
