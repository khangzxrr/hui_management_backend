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

  public double totalAliveAmount { get; set; }
  public double totalDeadAmount { get; set; }
  public double fundRatio { get; set; }
  public double totalProcessingAmount { get; set; }
  public double totalDebtAmount { get; set; }
  public double totalTakenAmount { get; set; }
}
