using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;
using hui_management_backend.Web.Constants;
using hui_management_backend.Web.Endpoints.DTOs;
using hui_management_backend.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class Create : EndpointBaseAsync
  .WithRequest<CreateRequest>
  .WithActionResult<CreateResponse>
{

  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<User> _userRepository;
  private readonly IMapper _mapper;

  public Create(IRepository<User> userRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _userRepository = userRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPost(CreateRequest.Route)]
  [SwaggerOperation(
    Summary = "Create new user",
    Description = "Create new user",
    OperationId = "SubUsers.create",
    Tags = new[] { "SubUsers" }
    )
  ]
  public override async Task<ActionResult<CreateResponse>> HandleAsync([FromBody] CreateRequest request, CancellationToken cancellationToken = default)
  {
    var owner = await _userRepository.GetByIdAsync(_authorizeService.UserId);

    if (owner == null)
    {
      return BadRequest(ResponseMessageConstants.OwnerNotFound);
    }

    var userSpec = new UserByPhoneNumberSpec(request.phonenumber);
    var user = await _userRepository.FirstOrDefaultAsync(userSpec);

    SubUser subUser = null!;
   
    if (user != null)
    {
      if (user.SubUserOfOwnerById(owner.Id) != null)
      {
        return BadRequest(ResponseMessageConstants.SubUserAlreadyExist);
      }

      subUser = user.AddSubUser(request.imageUrl, request.identity, request.identityCreateAt, request.identityAddress, request.identityFrontImageUrl, request.identityBackImageUrl, request.nickName, request.name, request.address, request.bankname, request.banknumber, request.additionalInfo, owner);

      await _userRepository.UpdateAsync(user);  

    } else
    {
      user = new User(request.phonenumber, "123123aaa", RoleName.User);
      subUser = user.AddSubUser(request.imageUrl, request.identity, request.identityCreateAt, request.identityAddress, request.identityFrontImageUrl, request.identityBackImageUrl, request.nickName, request.name, request.address, request.bankname, request.phonenumber, request.additionalInfo, owner);

      await _userRepository.AddAsync(user);
    }

    await _userRepository.SaveChangesAsync();

    var response = new CreateResponse(_mapper.Map<SubUserRecord>(subUser));


    return Ok(response);
  }
}
