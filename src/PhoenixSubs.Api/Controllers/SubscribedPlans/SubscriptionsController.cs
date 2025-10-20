using Microsoft.AspNetCore.Mvc;
using PhoenixSubs.Application;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Api;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController(
    SubscriptionPlanApplicationService subsService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscribedPlanDto>>> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await subsService.GetAllAsync(cancellationToken);

        return Ok(result);
    }
}
