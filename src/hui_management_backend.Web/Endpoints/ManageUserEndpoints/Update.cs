using Ardalis.ApiEndpoints;
using AutoMapper;
using hui_management_backend.Core.Constants;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class Update : EndpointBaseAsync
  .WithRequest<UpdateRequest>
  .WithActionResult<UpdateResponse>
{

  private readonly IRepository<User> _userRepository;

  private readonly IMapper _mapper;

  public Update(IRepository<User> userRepository, IMapper mapper)
  {
    _userRepository = userRepository;
    _mapper = mapper;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPut(UpdateRequest.Route)]
  [SwaggerOperation(
    Summary = "Update a user",
    Description = "Update a user",
    OperationId = "Users.update",
    Tags = new[] { "Users" }
    )
  ]
  public override async Task<ActionResult<UpdateResponse>> HandleAsync(UpdateRequest request, CancellationToken cancellationToken = default)
  {
    var user = await _userRepository.GetByIdAsync(request.id);

    if (user == null)
    {
      return NotFound();
    }

    user.UpdateImageUrl(request.imageUrl);
    user.UpdateIdentity(request.identity);
    user.UpdateIdentityAddress(request.identityAddress);
    user.UpdateIdentityCreateDate(request.identityCreateDate);
    user.UpdateName(request.name);
    user.UpdateNickName(request.nickName);
    user.UpdatePhoneNumber(request.phonenumber);
    user.UpdateBankNumber(request.banknumber);
    user.UpdateBankName(request.bankname);
    user.UpdateAddress(request.address);
    user.UpdateAdditionalInfo(request.additionalInfo);
    user.UpdateIdentityImageBackUrl(request.identityImageBackUrl);
    user.UpdateIdentityImageFrontUrl(request.identityImageFrontUrl);

    await _userRepository.UpdateAsync(user);

    await _userRepository.SaveChangesAsync();

    var response = new UpdateResponse(_mapper.Map<UserRecord>(user));

    return Ok(response);
  }
}
