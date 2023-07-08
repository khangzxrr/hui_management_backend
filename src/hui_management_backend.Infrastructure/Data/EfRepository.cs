using Ardalis.Specification.EntityFrameworkCore;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
