using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPracitce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Name = "Alma", Price = 20});
        }

        [HttpGet]
        [Route("all")]
        public IActionResult Getall()
        {
            return Ok(new List<object> { new { Name = "Alma", Price = 20 }, new { Name = "Armud", Price = 15 } });
        }
    }
}
