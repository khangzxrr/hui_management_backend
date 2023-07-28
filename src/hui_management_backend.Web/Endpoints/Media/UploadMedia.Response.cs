namespace hui_management_backend.Web.Endpoints.Media;

public class UploadMediaResponse
{
  public string MediaUrl { get; set; }

  public UploadMediaResponse(string mediaUrl)
  {
    MediaUrl = mediaUrl;
  }
}
