using hui_management_backend.Web.Endpoints.DTOs;

namespace hui_management_backend.Web.Endpoints.UserEndpoints;

public class GetAllResponse
{
  public IEnumerable<UserRecord> Users { get; set; } = null!;

}
