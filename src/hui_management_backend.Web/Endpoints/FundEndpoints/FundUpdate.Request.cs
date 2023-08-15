using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundUpdateRequest
{
  public const string Route = "/funds";

  [Required]
  public int id { get; set; }

  [Required]
  public string name { get; set; } = null!;
  [Required]
  public int newSessionDurationDayCount { get; set; }
  [Required]
  public int takenSessionDeliveryDayCount { get; set; }
  [Required]
  public DateTimeOffset openDate { get; set; }
  [Required]
  public double fundPrice { get; set; }
  [Required]
  public double serviceCost { get; set; }
}
