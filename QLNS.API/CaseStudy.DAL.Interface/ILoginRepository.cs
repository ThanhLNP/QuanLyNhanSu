using CaseStudy.Domain.Response.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.DAL.Interface
{
    public interface ILoginRepository
    {
        int Login(Login login);
    }
}
