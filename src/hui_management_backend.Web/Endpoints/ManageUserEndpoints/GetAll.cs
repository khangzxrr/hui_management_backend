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
  private readonly IRepository<SubUser> _subuserRepository;

  public GetAll(IRepository<SubUser> subuserRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _subuserRepository = subuserRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpGet(GetAllRequest.Route)]
  [SwaggerOperation(
    Summary = "Get all users",
    Description = "Get all users",
    OperationId = "SubUsers.getAll",
    Tags = new[] { "SubUsers" }
    )
  ]
  public override async Task<ActionResult<GetAllResponse>> HandleAsync([FromRoute] GetAllRequest request, CancellationToken cancellationToken = default)
  {
    IEnumerable<SubUser> subusers;

    var userWithPaymentSpec = new SubUserWithPaymentByCreatorIdSpec(_authorizeService.UserId);
    subusers = await _subuserRepository.ListAsync(userWithPaymentSpec);

    var userRecords = subusers.Where(s => s.rootUser.Id != _authorizeService.UserId).Select(_mapper.Map<SubUserRecord>).ToList();




    if (request.filterByAnyPayment.HasValue)
    {
      subusers = subusers
        .Where(u => u.Payments.Any() && u.rootUser.Id != _authorizeService.UserId);

      var filteredUserRecord = new List<SubUserRecord>();

      foreach(var subuser in subusers)
      {
        var subuserRecord = _mapper.Map<SubUserRecord>(subuser);

        subuserRecord.totalProcessingAmount = subuser.Payments.Where(p => p.Status != PaymentStatus.Finish).Sum(p => p.TotalCost);
        subuserRecord.totalDebtAmount = subuser.Payments.Where(p => p.Status != PaymentStatus.Finish).Sum(p => p.TotalTransactionCost);

        filteredUserRecord.Add(subuserRecord);
      }

      userRecords = filteredUserRecord;
    }


    if (request.filterByNotFinishedPayment.HasValue)
    {
      var unfinishedPaymentSubusers = subusers
        .Where(u => 
          u.Payments.Where(p => p.Status != PaymentStatus.Finish).Any() && u.rootUser.Id != _authorizeService.UserId);

      userRecords = unfinishedPaymentSubusers.Select(_mapper.Map<SubUserRecord>).ToList();
    }



    var response = new GetAllResponse
    {
      SubUsers = userRecords
    };

    return Ok(response);
  }
}
