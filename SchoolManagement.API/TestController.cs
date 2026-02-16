using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Infrastructure.Persistence;

namespace SchoolManagement;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private readonly SchoolDbContext _context;

    public TestController(SchoolDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> TestConnection()
    {
        var canConnect = await _context.Database.CanConnectAsync();
        return Ok($"Połączenie z bazą: {canConnect}");
    }
}