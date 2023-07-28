
using hui_management_backend.SharedKernel;
using hui_management_backend.SharedKernel.Interfaces;

namespace hui_management_backend.Core.MediaAggregate;
public class Media : EntityBase, IAggregateRoot
{
  public required string name { get; set; } 
}
