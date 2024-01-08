using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("To jest testowa wiadomość z kontrolera TestController.");
        }
    }
}
