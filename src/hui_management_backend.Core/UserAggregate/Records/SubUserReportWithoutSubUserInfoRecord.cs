
namespace hui_management_backend.Core.UserAggregate.Records;
public record SubUserReportWithoutSubUserInfoRecord(
  double totalAliveAmount, 
  double totalDeadAmount, 
  double fundRatio, 
  double totalProcessingAmount, 
  double totalDebtAmount, 
  double totalTakenAmount, 
  double totalUnfinishedTakenAmount,
  double totalOutsideDebt);
