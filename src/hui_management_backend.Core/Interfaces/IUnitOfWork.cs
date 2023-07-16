

namespace hui_management_backend.Core.Interfaces;
public interface IUnitOfWork
{
  void BeginTransaction();
  void CommitTransaction();
  void RollbackTransaction();
  void Dispose();

  Task<int> SaveChangesAsync();
  Task SaveAndCommitAsync();
}
