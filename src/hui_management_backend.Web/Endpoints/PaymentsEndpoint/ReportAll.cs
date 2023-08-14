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
using hui_management_backend.Web.Endpoints.DTOs;
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
  private readonly IRepository<SubUser> _subuserRepository;
  private readonly IMapper _mapper;

  public ReportAll(IAuthorizeService authorizeService, IRepository<Fund> fundRepository, IRepository<SubUser> subuserRepository, IMapper mapper)
  {
    _authorizeService = authorizeService;
    _fundRepository = fundRepository;
    _subuserRepository = subuserRepository;
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
    var subuserSpec = new SubUserWithPaymentByCreatorIdSpec(_authorizeService.UserId);
    var subusers = await _subuserRepository.ListAsync(subuserSpec);

    List<SubUserRecord> subuserReports = new();

    foreach (var subuser in subusers)
    {
      if (subuser.rootUser.Id == _authorizeService.UserId)
      {
        continue;
      }

      var subuserReport = _mapper.Map<SubUserRecord>(subuser);

      subuserReport.totalProcessingAmount = subuser.Payments.Where(p => p.Status == PaymentStatus.Processing)
              .Sum(p => p.TotalCost);

      subuserReport.totalDebtAmount = subuser.Payments.Where(p => p.Status == PaymentStatus.Debting).Sum(p => p.TotalCost);

      subuserReports.Add(subuserReport);
    }

    var spec = new FundsByOwnerIdSpec(_authorizeService.UserId);
    var funds = await _fundRepository.ListAsync(spec);

    foreach (var fund in funds)
    {
      foreach (var session in fund.Sessions)
      {
        foreach (var sessionDetail in session.normalSessionDetails)
        {

          var userReport = subuserReports.Where(u => u.Id == sessionDetail.fundMember.subUser.Id).FirstOrDefault();

          if (userReport == null)
          {
            continue;
          }



          if (sessionDetail.type == NormalSessionType.Alive)
          {
            userReport.totalAliveAmount += sessionDetail.payCost;
            userReport.fundRatio += sessionDetail.payCost;
          }
          else if (sessionDetail.type == NormalSessionType.Dead)
          {
            userReport.totalDeadAmount += sessionDetail.payCost;
            userReport.fundRatio -= sessionDetail.payCost;
          } else if (sessionDetail.type == NormalSessionType.Taken)
          {
            userReport.totalTakenAmount += sessionDetail.payCost;
            userReport.fundRatio -= sessionDetail.payCost;
          }

        }
      }
    }


    var response = new ReportAllResponse(subuserReports);

    return Ok(response);
  }
}
