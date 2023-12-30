using Xunit;
using hui_management_backend.Core.FundAggregate.Specifications;
namespace hui_management_backend.UnitTests.Core.FundAggregate;
public class FundPaginationTest
{

  [Fact]
  public void ReturnCorrectSkipTakeGivenSpec()
  {
    var spec = new FundsByOwnerIdSpec(1, 10, 5);

    Assert.Equal(5, spec.Skip);
    Assert.Equal(10, spec.Take);
  }

}
