using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.Base;

public abstract class PagingRequest
{
  [Required]
  [FromQuery]
  [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
  public int pageIndex { get; set; }
  [Required]
  [FromQuery]
  [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
  public int pageSize { get; set; }

  public int skip => pageIndex * pageSize;

}
