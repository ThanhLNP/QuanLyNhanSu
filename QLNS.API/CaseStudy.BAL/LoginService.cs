using CaseStudy.BAL.Interface;
using CaseStudy.Domain.Response.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.BAL
{
    public class LoginService : ILoginService
    {
        protected ILoginService _login;
        public LoginService(ILoginService login)
        {
            _login = login;
        }
        public int Login(Login login)
        {
            return _login.Login(login);
        }
    }
}
