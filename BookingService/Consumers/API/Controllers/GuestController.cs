using Application;
using Application.Guest.DTO;
using Application.Guest.Port;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GuestController(ILogger<GuestController> logger, IGuestManager guestManager) : Controller
{
    private readonly ILogger<GuestController> _logger = logger;
    private readonly IGuestManager _guestManager = guestManager;

    [HttpPost]
    public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
    {
        var request = new Application.Guest.Requests.GuestRequest
        {
            guestDTO = guest
        };

        var res = await _guestManager.SaveAsync(request);

        if (res.Success) return Created("", res.guestDTO);

        if (res.ErrorCode == ErrorCodes.NOT_FOUND)
            return BadRequest(res);

        _logger.LogError("Response with unknow ErrorCode Returned", res);
        return BadRequest(500);
    }
}
