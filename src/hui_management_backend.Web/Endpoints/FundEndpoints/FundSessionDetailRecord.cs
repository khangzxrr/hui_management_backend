namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record FundSessionDetailRecord(int id, double predictedPrice, double fundAmount, double remainPrice, double ownerCost, bool isTaken, FundMemberRecord fundMember);
