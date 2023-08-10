using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class CreateRequest
{

  public const string Route = "/subusers";

  [Required]
  public string imageUrl { get; set; } = null!;
  [Required]
  public string name { get; set; } = null!;
  [Required]
  public string nickName { get; set; } = null!;

  [Required]
  [RegularExpression("^[0-9]*$", ErrorMessage = "identity must be numeric")]
  public string identity { get; set; } = null!;
  [Required]
  public DateTimeOffset identityCreateAt { get; set; }
  [Required]
  public string identityAddress { get; set; } = null!;


  [Required]
  [RegularExpression("^[0-9]*$", ErrorMessage = "phone number must be numeric")]
  public string phonenumber { get; set; } = null!;
  [Required]
  public string bankname { get; set; } = null!;
  [Required]
  [RegularExpression("^[0-9]*$", ErrorMessage = "bank number must be numeric")]
  public string banknumber { get; set; } = null!;
  [Required]
  public string address { get; set; } = null!;
  public string additionalInfo { get; set; } = "";

  public string? identityFrontImageUrl { get; set; }
  public string? identityBackImageUrl { get; set; }

}
