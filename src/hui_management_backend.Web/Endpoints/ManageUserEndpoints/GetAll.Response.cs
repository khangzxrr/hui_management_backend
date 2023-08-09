using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAllResponse
{
  public IEnumerable<SubUserRecord> SubUsers { get; set; } = null!;

}
