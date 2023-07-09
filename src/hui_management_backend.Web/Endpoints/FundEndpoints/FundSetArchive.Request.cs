using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundSetArchiveRequest
{
  public const string Route = "/funds/{id}/archive";

  [FromRoute]
  public int id { get; set; }

  [FromQuery]
  [Required]
  public bool isArchived { get; set; }

}
