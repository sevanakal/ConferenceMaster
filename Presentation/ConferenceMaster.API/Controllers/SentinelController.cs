using ConferenceMaster.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ConferenceMaster.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SentinelController : ControllerBase
{
    private readonly ISentinelService _sentinelService;

    public SentinelController(ISentinelService sentinelService)
    {
        _sentinelService = sentinelService;
    }

    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        //Gözcü sistem sağlığını kontrol ediyor
        var isHealthy = _sentinelService.IsSystemHealthy();

        if (isHealthy)
        {
            return Ok(new
            {
                Status="Online",
                Message="Sentinel Aktif, Sistem ve veritabanı bağlantısı sağlıklı.",
                Timestamp=DateTime.UtcNow
            });
        }

        return StatusCode(503, new
        {
            Status="Offline",
            Message="Sentinel Pasif, Sistem veya veritabanı bağlantısında sorun var.",
            Timestamp=DateTime.UtcNow
        });
    }
}
