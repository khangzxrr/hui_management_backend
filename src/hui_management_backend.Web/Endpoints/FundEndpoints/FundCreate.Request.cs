using System.ComponentModel.DataAnnotations;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundCreateRequest
{
  public const string Route = "/funds";

  [Required]
  public string name { get; set; } = null!;
  [Required]
  public DateTime openDate { get; set; }
  [Required]
  public int NewSessionDurationCount { get; set; }
  [Required]
  public int TakenSessionDeliveryCount { get; set; }
  [Required]
  public int NewSessionCreateDayOfMonth { get; set; }
  [Required]
  public DateTime NewSessionCreateHourOfDay { get; set; }
  [Required]
  public DateTime takenSessionDeliveryHourOfDay { get; set; }

  [Required]
  public double fundPrice { get; set; }
  [Required]
  public double serviceCost { get; set; }
  [Required]
  public string fundType { get; set; } = null!;
  
}
