namespace hui_management_backend.Web.Endpoints.DTOs;

public record CustomBillRecord(int id, string description, double payCost, string type)
{
}
