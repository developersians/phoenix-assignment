using Microsoft.AspNetCore.Mvc;
using PhoenixSubs.Application;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Api;

[ApiController]
[Route("api/[controller]")]
public class PlansController(
    PlanApplicationService planAppService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlanDto>>> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await planAppService.GetAllAsync(cancellationToken);

        return Ok(result);
    }
}
