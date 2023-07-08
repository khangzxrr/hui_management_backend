﻿using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class CreateRequest
{

  public const string Route = "/users";

  [Required]
  public string name { get; set; } = null!;
  [Required]
  public string password { get; set; } = null!;
  [Required]
  [DataType(DataType.EmailAddress)]
  public string email { get; set; } = null!;
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

}
