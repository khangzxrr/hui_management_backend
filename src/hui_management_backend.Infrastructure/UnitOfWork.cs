
using hui_management_backend.Core.Interfaces;
using hui_management_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace hui_management_backend.Infrastructure;
public class UnitOfWork  : IUnitOfWork
{

  private AppDbContext _appDbContext;
  private IDbContextTransaction? _transaction;

  public UnitOfWork(AppDbContext appDbContext)
  {
    _appDbContext = appDbContext;
  }

  public void BeginTransaction()
  {
    if (_transaction != null)
    {
      return;
    }

    _transaction = _appDbContext.Database.BeginTransaction();
  }

  public void CommitTransaction() { 
    if (_transaction == null) {
      return;
    }

    _transaction.Commit();
    _transaction.Dispose();
    _transaction = null;
  }

  public void Dispose()
  {
    if (_transaction == null)
    {
      return;
    }

    _transaction.Dispose();
    _transaction = null;
  }

  public void RollbackTransaction()
  {
    if (_transaction == null)
    {
      return;
    }

    _transaction.Rollback();
    _transaction.Dispose();
    _transaction = null;
  }

  public async Task SaveAndCommitAsync()
  {
    await SaveChangesAsync();
    CommitTransaction();
  }

  public Task<int> SaveChangesAsync()
  {
    return _appDbContext.SaveChangesAsync();
  }
}
