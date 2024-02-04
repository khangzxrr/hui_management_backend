using hui_management_backend.Core.UserAggregate.Records;

namespace hui_management_backend.Web.Endpoints.DTOs;

public class SubUserReportRecord : SubUserRecord
{
  public SubUserReportRecord(
    int id, 
    string imageUrl, 
    string identity, 
    DateTime identityCreateDate, 
    string identityAddress, 
    string? identityImageFrontUrl, 
    string? identityImageBackUrl, 
    string nickName, 
    string name, 
    string address, 
    string bankName, 
    string bankNumber, 
    string phoneNumber, 
    string additionalInfo) : base(id, imageUrl, identity, identityCreateDate, identityAddress, identityImageFrontUrl, identityImageBackUrl, nickName, name, address, bankName, bankNumber, phoneNumber, additionalInfo)
  {
  }

  public double totalAliveAmount { get; private set; }
  public double totalDeadAmount { get; private set; }
  public double fundRatio { get; private set; }
  public double totalProcessingAmount { get; private set; }
  public double totalDebtAmount { get; private set; }
  public double totalTakenAmount { get; private set; }
  public double totalUnfinishedTakenAmount { get; private set; }

  public double totalOutsideDebt { get; private set; }

  public void setReport(SubUserReportWithoutSubUserInfoRecord report)
  {
    totalAliveAmount = report.totalAliveAmount;
    totalDeadAmount = report.totalDeadAmount;
    fundRatio = report.fundRatio;
    totalProcessingAmount = report.totalProcessingAmount;
    totalDebtAmount = report.totalDebtAmount;
    totalTakenAmount = report.totalTakenAmount;
    totalUnfinishedTakenAmount = report.totalUnfinishedTakenAmount;
    totalOutsideDebt = report.totalOutsideDebt;
  }
}
