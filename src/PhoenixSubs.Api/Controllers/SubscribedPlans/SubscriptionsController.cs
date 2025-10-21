using Microsoft.AspNetCore.Mvc;
using PhoenixSubs.Application;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Api;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController(
    SubscriptionPlanApplicationService subscriptionPlanAppService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscribedPlanDto>>> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await subscriptionPlanAppService.GetAllAsync(cancellationToken);

        return Ok(result);
    }
}
