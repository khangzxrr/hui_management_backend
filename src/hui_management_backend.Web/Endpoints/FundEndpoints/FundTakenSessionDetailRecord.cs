namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record FundTakenSessionDetailRecord(int id, double predictedPrice, double fundAmount, double remainPrice, double serviceCost, FundMemberRecord fundMember);
