using Microsoft.AspNetCore.Mvc;

namespace OrderProcessing.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK");
        }
    }
}