

using System.ComponentModel.DataAnnotations;
using Azure.Core;
using hui_management_backend.Web.Endpoints.Base;
using hui_management_backend.Web.Endpoints.FundEndpoints;
using Xunit;

namespace hui_management_backend.UnitTests.Web;
public class PaginationTest
{

  [Fact]
  void ReturnCorrectSkipGivenPageIndexPageSize()
  {
    var request = new FundGetAllRequest
    {
      pageIndex = 3,
      pageSize = 10,
    };

    Assert.Equal(30, request.skip);
  }

  [Fact]
  void ReturnErrorWhenGivenNegativePageIndexOrPageSize()
  {
    var request = new FundGetAllRequest
    {
      pageIndex = -10,
      pageSize = 10,
    };

    Assert.Contains(UnitTestHelper.ValidateModel(request),
      r => r.ErrorMessage!.Contains("Please enter a value bigger than"));

    request = new FundGetAllRequest
    {
      pageIndex = 10,
      pageSize = -10,
    };

    Assert.Contains(UnitTestHelper.ValidateModel(request),
      r => r.ErrorMessage!.Contains("Please enter a value bigger than"));
  }
}
