using CaseStudy.DAL.Interface;
using CaseStudy.Domain.Response.Login;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;

namespace CaseStudy.DAL
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public int Login(Login login)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email", login.Email);
                parameters.Add("@MatKhau", login.MatKhau);
                var result= SqlMapper.ExecuteScalar<int>(con, "sp_Login", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }catch(Exception exp)
            {
                throw exp;
            }
        }
    }
}
