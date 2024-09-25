using Client.IBLL;
using Client.IDAL;

namespace Client.BLL
{
    public class LoginBLL : ILoginBLL
    {
        private ILoginDal _loginDal;
        public LoginBLL(ILoginDal ILoginDal)
        {
            this._loginDal = ILoginDal;
        }
        public async Task<bool> Login(string username, string password)
        {
            var loginstr = await _loginDal.Login(username, password);  
             
            return false;
        }
    }
}