using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
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

    var userRecords = users.Select(_mapper.Map<UserRecord>);


    if (request.filterByAnyPayment.HasValue)
    {
      users = users.Where(u => u.Payments.Any());

      var filteredUserRecord = new List<UserRecord>();

      foreach(var user in users)
      {
        var userRecord = _mapper.Map<UserRecord>(user);

        userRecord.totalCost = user.Payments.Sum(p => p.TotalCost);
        userRecord.totalTransactionCost = user.Payments.Sum(p => p.TotalTransactionCost);

        filteredUserRecord.Add(userRecord);
      }

      userRecords = filteredUserRecord;
    }


    if (request.filterByNotFinishedPayment.HasValue)
    {
      var unfinishedPaymentUser = users.Where(u => u.Payments.Where(p => p.Status != PaymentStatus.Finish).Any());

      userRecords = unfinishedPaymentUser.Select(_mapper.Map<UserRecord>);
    }

    var response = new GetAllResponse
    {
      Users = userRecords
    };

    return Ok(response);
  }
}
