using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundCreateRequest
{
  public const string Route = "/funds";

  [Required]
  public string name { get; set; } = null!;
  [Required]
  public DateTimeOffset openDate { get; set; }
  [Required]
  public int NewSessionDurationDayCount { get; set; }
  [Required]
  public int TakenSessionDeliveryDayCount { get; set; }
  [Required]
  public double fundPrice { get; set; }
  [Required]
  public double serviceCost { get; set; }
 
}
