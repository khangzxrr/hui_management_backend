using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.Media;

public class UploadMediaRequest
{
  public const string Route = "/Media/Upload";

  [Required]
  [DataType(DataType.Upload)]
  public required IFormFile Media { get; set; }
}
