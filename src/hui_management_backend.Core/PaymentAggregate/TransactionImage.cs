
using hui_management_backend.SharedKernel;

namespace hui_management_backend.Core.PaymentAggregate;
public class TransactionImage : EntityBase
{
  public required string ImageUrl { get; set; }
}
