using System.ComponentModel.DataAnnotations;
using Ardalis.SmartEnum;
using hui_management_backend.Core.PaymentAggregate;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class AddCustomBillRequestBody
{
  [Required]
  [SmartEnumName(typeof(CustomBillType))]
  public required string customBillType { get; set; }

  [Required]
  public required double amount { get; set; }

  [Required]
  public string description { get; set; } = string.Empty;
}
