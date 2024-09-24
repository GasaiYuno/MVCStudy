using Microsoft.AspNetCore.Mvc;
using Server.IService;
using Server.Models;

namespace Server.Start.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        ILoginService _loginService;
        public UserController(ILoginService loginService) {
            _loginService = loginService;
        }


        [HttpGet]
        [Route("login")]
        public string Login()
        {
            return "Login in Get";
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromForm]string userName, [FromForm]string password)
        {
            var user = _loginService.Query<SysUserInfo>(t => t.UserName == userName && t.Password == password);

            if (user?.Count() > 0)
            {
                return Ok("成功登录");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
