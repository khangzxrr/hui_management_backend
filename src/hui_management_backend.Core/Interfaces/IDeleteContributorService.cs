using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
