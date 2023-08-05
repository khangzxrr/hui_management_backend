using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UpdateRequest
{
  public const string Route = "/users";
  [Required]
  public int id { get; set; }
  [Required]
  public string imageUrl { get; set; } = null!;

  [Required]
  public string nickName { get; set; } = null!;

  [Required]
  public string name { get; set; } = null!;
  [Required]
  public string password { get; set; } = null!;
  [Required]
  public string identity { get; set; } = null!;
  [Required]
  public string identityAddress { get; set; } = null!;
  [Required]
  public DateTimeOffset identityCreateDate { get; set; }

  [Required]
  public string phonenumber { get; set; } = null!;
  [Required]
  public string bankname { get; set; } = null!;
  [Required]
  public string banknumber { get; set; } = null!;
  [Required]
  public string address { get; set; } = null!;
  public string additionalInfo { get; set; } = "";
  public string? identityImageFrontUrl { get; set; }
  public string? identityImageBackUrl { get; set; }
}
