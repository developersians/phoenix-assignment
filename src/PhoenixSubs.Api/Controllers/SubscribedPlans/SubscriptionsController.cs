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

    [HttpPost("activate")]
    public async Task<ActionResult<bool>> Activate(
        ActivateSubscriptionRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await subscriptionPlanAppService.ActivateAsync(
            request.UserId,
            request.PlanId,
            cancellationToken);

        return result
            ? Ok(result)
            : BadRequest(result);
    }

    [HttpPost("deactivate")]
    public async Task<ActionResult<IEnumerable<SubscribedPlanDto>>> Deactivate(
        DeactivateSubscriptionRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await subscriptionPlanAppService.Deactivate(
            request.UserId,
            request.SubscriptionId,
            cancellationToken);

        return result
            ? Ok(result)
            : BadRequest(result);
    }
}
