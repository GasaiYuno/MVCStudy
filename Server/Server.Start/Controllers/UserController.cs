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
            var users = _loginService.Query<SysUserInfo>(t => t.UserName == userName && t.Password == password);

            if (users?.Count() > 0)
            {
                var userInfo = users.ToList();
                SysUserInfo sysUserInfo = userInfo[0];
                return Ok(sysUserInfo);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Route("insert")]
        public ActionResult Insert([FromForm]string userName, [FromForm]string password)
        {
            try
            {
                var user = _loginService.Insert<SysUserInfo>(new SysUserInfo { UserName = userName, Password = password });
                return Ok("插入成功");
            }catch(Exception)
            {
                throw ;
               
            }
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromForm] string userName, [FromForm] string password)
        {
            try
            {
                var user = _loginService.Query<SysUserInfo>(t => t.UserName == userName);
                if (user?.Count() > 0)
                {
                    user.First().Password= password;
                    _loginService.Update<SysUserInfo>(user);
                    return Ok(user.First());
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            { throw ; }
        }
    }
}
