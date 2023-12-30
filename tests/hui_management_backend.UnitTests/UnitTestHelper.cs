
using System.ComponentModel.DataAnnotations;
using hui_management_backend.Core.FundAggregate;

namespace hui_management_backend.UnitTests;
public class UnitTestHelper
{
  public static IList<ValidationResult> ValidateModel(object model)
  {
    var validationResults = new List<ValidationResult>();
    var ctx = new ValidationContext(model, null, null);
    Validator.TryValidateObject(model, ctx, validationResults, true);
    return validationResults;
  }
  public static List<Fund> funds = new List<Fund>
    {
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund),
      new Fund("Hụi ngày", 1, 1, 0, DateTime.Now, DateTime.Now, DateTime.Now, 1500000.0, 300000.0, FundType.DayFund)

    };
}
