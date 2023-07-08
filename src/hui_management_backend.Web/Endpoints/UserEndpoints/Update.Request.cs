using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class UpdateRequest
{
  public const string Route = "/users";
  [Required]
  public int id { get; set; } 
  [Required]
  public string name { get; set; } = null!;
  [Required]
  public string password { get; set; } = null!;
  [Required]
  public string email { get; set; } = null!;
  [Required]
  public string phonenumber { get; set; } = null!;
  [Required]
  public string bankname { get; set; } = null!;
  [Required]
  public string banknumber { get; set; } = null!;
  [Required]
  public string address { get; set; } = null!;
  public string additionalInfo { get; set; } = "";
}
