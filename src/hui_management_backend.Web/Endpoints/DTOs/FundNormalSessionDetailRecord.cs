namespace hui_management_backend.Web.Endpoints.DTOs;

public record FundNormalSessionDetailRecord(int id, double predictedPrice, double fundAmount, double lossCost, double serviceCost, double payCost, string type, FundMemberRecord fundMember);
