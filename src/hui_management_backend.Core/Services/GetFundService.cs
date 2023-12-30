
using Ardalis.Result;
using hui_management_backend.Core.FundAggregate;
using hui_management_backend.Core.FundAggregate.Specifications;
using hui_management_backend.Core.Interfaces;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.Services;
public class GetFundService : IGetFundService
{
  private readonly IRepository<Fund> _fundRepository;

  public GetFundService(IRepository<Fund> fundRepository)
  {
    _fundRepository = fundRepository;
  }

 

  public async Task<Result<IEnumerable<Fund>>> getFunds(int ownerId, int skip, int take, string? searchTerm)
  {

    var spec = new FundsByOwnerIdSpec(ownerId, skip, take, searchTerm);
    var funds = await _fundRepository.ListAsync(spec);
    return funds;
  }
}
