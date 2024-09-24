using Microsoft.AspNetCore.Mvc;

namespace Server.Start.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("login")]
        public string Login()
        {
            return "Login in Get";
        }

        [HttpPost]
        [Route("login")]
        public string Login([FromForm]string userName, [FromForm]string password)
        {
            return "Login in Post";
        }
    }
}
