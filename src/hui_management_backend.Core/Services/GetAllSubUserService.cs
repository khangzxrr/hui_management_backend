

using hui_management_backend.Core.Interfaces;
using hui_management_backend.Core.UserAggregate;
using hui_management_backend.Core.UserAggregate.Specifications;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetAllSubUserService : IGetAllSubUserService
{
  private readonly IRepository<SubUser> _subuserRepository;

  public GetAllSubUserService(IRepository<SubUser> subuserRepository)
  {
    _subuserRepository = subuserRepository;
  }

  public async Task<IEnumerable<SubUser>> GetSubUsers(int ownerId, int skip, int take, string? searchTerm)
  {
    var spec = new SubUserByCreateById(ownerId, skip, take, searchTerm?.Trim());  

    return await _subuserRepository.ListAsync(spec);  
  }
}
