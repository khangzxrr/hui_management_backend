using System.Net;
using Ardalis.ApiEndpoints;
using hui_management_backend.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace hui_management_backend.Web.Endpoints.Media;

public class GetMedia : EndpointBaseAsync
  .WithRequest<GetMediaRequest>
  .WithActionResult
{

  private readonly  IMediaService _mediaService;

  public GetMedia(IMediaService mediaService)
  {
    _mediaService = mediaService;
  }

  [HttpGet(GetMediaRequest.Route)]
  [SwaggerOperation(
       Summary = "Get media by name",
       Description = "Get media by name",
       OperationId = "Media.GetMedia",
       Tags = new[] { "Media" })
     ]

  public override async Task<ActionResult> HandleAsync([FromRoute] GetMediaRequest request, CancellationToken cancellationToken = default)
  {
    var downloadUrlResult = await _mediaService.Download(request.MediaName);

    if (!downloadUrlResult.IsSuccess)
    {
      return BadRequest(downloadUrlResult.Errors);
    }

    HttpClient httpClient = new HttpClient();

    Stream stream = await httpClient.GetStreamAsync(downloadUrlResult.Value);

    //get file extension from request.MediaName
    string extension = request.MediaName.Split('.').Last();

    return File(stream, $"image/{extension}", request.MediaName);
  }
}
