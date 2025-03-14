﻿using Microsoft.AspNetCore.Mvc;

namespace hui_management_backend.Web.Endpoints.PaymentsEndpoint;

public class GetUserPaymentsRequest
{
  public const string Route = "/owner/subusers/{subUserId}/payments";

  [FromRoute]
  public int subUserId { get; set; }

  [FromQuery]
  public DateTime? filerByDate { get; set; }

  [FromQuery]
  public int? filterBySessionDetailId { get; set; }

  [FromQuery]
  public bool? filterByProcessingOrDebting { get; set; }
}
