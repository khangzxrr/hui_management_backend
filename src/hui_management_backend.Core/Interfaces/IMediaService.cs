
using Ardalis.Result;

namespace hui_management_backend.Core.Interfaces;
public interface IMediaService 
{
  public Task<Result<string>> Upload(Stream fileStream, string fileName);
  public Task<Result<string>> Download(string fileName);
}
