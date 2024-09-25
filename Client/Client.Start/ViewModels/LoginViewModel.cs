using Client.IBLL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Client.Start.ViewModels
{
    public class LoginViewModel:BindableBase
    {
        private string _username;
        public string Username { get { return _username; } set { SetProperty<string>(ref _username, value); } }

        private string _password;
        public string Password { get { return _password; } set { SetProperty<string>(ref _password, value); } }

        private string _errorMsg;
        public string ErrorMsg { get { return _errorMsg; } set { SetProperty<string>(ref _errorMsg, value); } }    

        public ICommand LoginCommand
        {
            get =>new DelegateCommand<object>(Login);
        }

        private ILoginBLL _iLoginBLL;
        public LoginViewModel(ILoginBLL ILoginBLL)
        {
            this._iLoginBLL = ILoginBLL;
        }

        private void Login(object obj)
        {
            try
            {
                if(string.IsNullOrEmpty(_username)) 
                {
                    this._errorMsg = "用户名为空";
                    return;
                }
                if (string.IsNullOrEmpty(_password))
                {
                    this._errorMsg = "密码为空";
                    return;
                }
                //检验登录账号密码
                if (_iLoginBLL.Login(_username, _password).GetAwaiter().GetResult())
                {

                }
                else
                {
                    this.ErrorMsg = "用户名或者密码错误";
                    return;
                }


            }catch(Exception ex)
            {

            }
        }
    }
}
