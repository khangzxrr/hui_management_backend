
namespace hui_management_backend.Core.UserAggregate.Enums;
public class SubUserWithPaymentReportFilter
{
  public bool? atLeastOnePayment { get; set; }
  public bool? todayPayment { get; set; }
  public bool? unfinishedPayment { get; set; }
  public bool? getProcessingAndDebtPaymentOnly {  get; set; }

  public SubUserWithPaymentReportFilter(bool? atLeastOnePayment, bool? todayPayment, bool? unfinishedPayment, bool? getProcessingAndDebtPaymentOnly)
  {
    this.atLeastOnePayment = atLeastOnePayment;
    this.todayPayment = todayPayment;
    this.unfinishedPayment = unfinishedPayment;
    this.getProcessingAndDebtPaymentOnly = getProcessingAndDebtPaymentOnly;
  }
}
