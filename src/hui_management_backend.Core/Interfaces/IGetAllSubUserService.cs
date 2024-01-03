
using hui_management_backend.Core.UserAggregate;

namespace hui_management_backend.Core.Interfaces;
public interface IGetAllSubUserService
{
  public Task<IEnumerable<SubUser>> GetSubUsers(int ownerId, int skip, int take, string? searchTerm);
}
