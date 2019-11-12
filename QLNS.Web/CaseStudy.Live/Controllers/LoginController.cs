using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CaseStudy.Live.Models.Login;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CaseStudy.Live.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            var LoginResult=0;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/login/login");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(login);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                LoginResult = int.Parse(result);
            }
            if (LoginResult == 1)
            {
                return RedirectToAction("#","NhanVien");
            }
            else if (LoginResult == 2)
            {
                return RedirectToAction("Index","NhanSu");
            }else if (LoginResult == 3)
            {
                return  RedirectToAction("#","#");
            }
            else
            {
                TempData["Fail"] = "Login Fail";
            }
            return RedirectToAction(nameof(Login));
            
        }
    }
}