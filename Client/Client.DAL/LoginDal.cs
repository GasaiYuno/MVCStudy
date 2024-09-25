using Client.IDAL;

namespace Client.DAL
{
    public class LoginDal :WebDataAccess, ILoginDal
    {
        public Task<string> Login(string username, string password)
        {
            Dictionary<string,HttpContent> contents= new Dictionary<string,HttpContent>();
            contents.Add("userName", new StringContent(username));
            contents.Add("password", new StringContent(password));
            return this.PostData("login", contents);
        }
    }
}