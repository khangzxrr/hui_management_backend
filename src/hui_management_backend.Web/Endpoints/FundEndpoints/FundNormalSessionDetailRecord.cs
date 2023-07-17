namespace hui_management_backend.Web.Endpoints.FundEndpoints;

public record FundNormalSessionDetailRecord(int id, double predictedPrice, double fundAmount, double serviceCost, double payCost, string type, FundMemberRecord fundMember);
