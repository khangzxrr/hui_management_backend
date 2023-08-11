
using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.PaymentAggregate;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UserGetPayments : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<UserGetPaymentsResponse>
{

  private readonly IRepository<SubUser> _subUserRepository;
  private readonly IMapper _mapper;
  private readonly IAuthorizeService _authorizeService;

  public UserGetPayments(IRepository<SubUser> subUserRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _subUserRepository = subUserRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
  }




  [Authorize(Roles = RoleNameConstants.User)]
  [HttpGet(UserGetPaymentsRequest.Route)]
  public override async Task<ActionResult<UserGetPaymentsResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var spec = new SubUserWithPaymentByRootUserIdSpec(_authorizeService.UserId);
    var subUsers = await _subUserRepository.ListAsync(spec);

    List<Payment> payments = subUsers.SelectMany(su => su.Payments).ToList();

    var response = new UserGetPaymentsResponse(payments.Select(_mapper.Map<PaymentRecord>));

    return Ok(response);
  }
}
