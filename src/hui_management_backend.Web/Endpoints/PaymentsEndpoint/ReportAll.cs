using System;
using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.PaymentAggregate.Specifications;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Endpoints.ManageUserEndpoints;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class ReportAll : EndpointBaseAsync
    .WithRequest<ReportAllRequest>
    .WithActionResult<ReportAllResponse>
{

  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<Fund> _fundRepository;
  private readonly IRepository<Payment> _paymentRepository;
  private readonly IRepository<User> _userRepository;
  private readonly IMapper _mapper;

  public ReportAll(IAuthorizeService authorizeService, IRepository<Fund> fundRepository, IRepository<User> userRepository, IMapper mapper, IRepository<Payment> paymentRepository)
  {
    _authorizeService = authorizeService;
    _paymentRepository = paymentRepository;
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

  public override async Task<ActionResult<ReportAllResponse>> HandleAsync([FromRoute] ReportAllRequest request, CancellationToken cancellationToken = default)
  {
    var userByCreatorIdSpec = new UserByCreatorIdSpec(_authorizeService.UserId);
    var users = await _userRepository.ListAsync(userByCreatorIdSpec);

    if (users == null)
    {
      return BadRequest();
    }


    List<UserReport> userReports = users.Select(_mapper.Map<UserReport>).ToList();

    if (request.getTotalCostRemain.HasValue)
    {

      foreach(var user in userReports)
      {
        var paymentSpec = new PaymentsByUserIdSpec(user.Id);
        var payments = await _paymentRepository.ListAsync(paymentSpec);

        user.totalCost = payments.Where(p => p.Status != PaymentStatus.Finish)
                .Sum(p => p.TotalCost);

        user.totalTransactionCost = payments.Where(p => p.Status != PaymentStatus.Finish)
                                            .Sum(p => p.TotalTransactionCost);
                
      }
    }

    if (request.getFundRatio.HasValue)
    {
      var spec = new FundsByOwnerIdSpec(_authorizeService.UserId);
      var funds = await _fundRepository.ListAsync(spec);

      foreach (var fund in funds)
      {
        foreach (var session in fund.Sessions)
        {
          foreach (var sessionDetail in session.normalSessionDetails)
          {

            var userReport = userReports.Where(u => u.Id == sessionDetail.fundMember.User.Id).FirstOrDefault();

            if (userReport == null)
            {
              continue;
            }


            if (sessionDetail.type == NormalSessionType.Alive)
            {
              userReport.fundRatio += sessionDetail.payCost;
            }
            else if (sessionDetail.type == NormalSessionType.Dead)
            {
              userReport.fundRatio -= sessionDetail.payCost;
            }

          }
        }
      }

    }



    var response = new ReportAllResponse(userReports);

    return Ok(response);
  }
}
