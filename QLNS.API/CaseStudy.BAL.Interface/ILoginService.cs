using CaseStudy.Domain.Response.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.BAL.Interface
{
    public interface ILoginService
    {
        int Login(Login login);
    }
}
