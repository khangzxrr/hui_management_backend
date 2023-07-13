using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public class FundGetRequest
{
  public const string Route = "/funds/{id}";

  [FromRoute]
  public int id { get; set; }
}
