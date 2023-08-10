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
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class Update : EndpointBaseAsync
  .WithRequest<UpdateRequest>
  .WithActionResult<UpdateResponse>
{


  private readonly IAuthorizeService _authorizeService;
  private readonly IRepository<SubUser> _subuserRepository;

  private readonly IMapper _mapper;

  public Update(IRepository<SubUser> subuserRepository, IMapper mapper, IAuthorizeService authorizeService)
  {
    _subuserRepository = subuserRepository;
    _mapper = mapper;
    _authorizeService = authorizeService;
  }

  [Authorize(Roles = RoleNameConstants.Owner)]
  [HttpPut(UpdateRequest.Route)]
  [SwaggerOperation(
    Summary = "Update a user",
    Description = "Update a user",
    OperationId = "SubUsers.update",
    Tags = new[] { "SubUsers" }
    )
  ]
  public override async Task<ActionResult<UpdateResponse>> HandleAsync(UpdateRequest request, CancellationToken cancellationToken = default)
  {
    var spec = new SubUserByIdSpec(request.id);
    var subUser = await _subuserRepository.FirstOrDefaultAsync(spec);

    if (subUser == null)
    {
      return NotFound(ResponseMessageConstants.SubUserAlreadyExist);
    }

    subUser.UpdateImageUrl(request.imageUrl);
    subUser.UpdateIdentity(request.identity);
    subUser.UpdateIdentityAddress(request.identityAddress);
    subUser.UpdateIdentityCreateDate(request.identityCreateDate);
    subUser.UpdateName(request.name);
    subUser.UpdateNickName(request.nickName);
    
    subUser.UpdateBankNumber(request.banknumber);
    subUser.UpdateBankName(request.bankname);
    subUser.UpdateAddress(request.address);
    subUser.UpdateAdditionalInfo(request.additionalInfo);
      
    subUser.UpdateIdentityImageBackUrl(request.identityImageBackUrl);
    subUser.UpdateIdentityImageFrontUrl(request.identityImageFrontUrl);



    await _subuserRepository.UpdateAsync(subUser);

    await _subuserRepository.SaveChangesAsync();

    var response = new UpdateResponse(_mapper.Map<SubUserRecord>(subUser));

    return Ok(response);
  }
}
