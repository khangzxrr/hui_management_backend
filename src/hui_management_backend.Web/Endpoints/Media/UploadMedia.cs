using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.Media;

public class UploadMedia : EndpointBaseAsync
  .WithRequest<UploadMediaRequest>
  .WithActionResult<UploadMediaResponse>
{

  private readonly IMediaService _mediaService;

  public UploadMedia(IMediaService mediaService)
  {
    _mediaService = mediaService;
  }

  [HttpPost(UploadMediaRequest.Route)]
  [SwaggerOperation(
       Summary = "Upload media",
       Description = "Upload media",
       OperationId = "Media.Upload",
       Tags = new[] { "Media" }
          )
     ]
  public override async Task<ActionResult<UploadMediaResponse>> HandleAsync([FromForm] UploadMediaRequest request, CancellationToken cancellationToken = default)
  {
    var result = await _mediaService.Upload(request.Media.OpenReadStream(), request.Media.FileName);

    if (!result.IsSuccess)
    {
      return BadRequest(result.Errors);
    }

    var response = new UploadMediaResponse(result.Value);

    return Ok(response);
  }
}
