using Microsoft.AspNetCore.Mvc;
using PhoenixSubs.Application;
using PhoenixSubs.Domain;

namespace PhoenixSubs.Api;

[ApiController]
[Route("api/[controller]")]
public class UsersController(
    UserApplicationService userAppService) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await userAppService.GetAllAsync(cancellationToken);

        return Ok(result);
    }
}
