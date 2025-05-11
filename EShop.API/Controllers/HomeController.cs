using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers;

[ApiController]
[Route("{Controller}")]
public class HomeController : ControllerBase
{
    //[HttpGet("index")]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok(new { Title = "Our EShop is ready for you" });
    }
}
