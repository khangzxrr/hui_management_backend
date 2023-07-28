using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.Media;

public class GetMediaRequest
{
  public const string Route = "/Media/{MediaName}";

  [Required]
  public string MediaName { get; set; } = default!;
}
