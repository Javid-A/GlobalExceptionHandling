using GlobalExceptionHandling.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ExceptionHandling]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Problem(statusCode:404);
            throw new Exception("This is my exception design");
            return Ok();
        }
    }
}
