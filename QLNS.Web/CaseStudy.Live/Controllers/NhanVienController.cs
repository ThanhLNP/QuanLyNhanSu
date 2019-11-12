using CaseStudy.Live.Models.NhanVien.Request;
using CaseStudy.Live.Models.NhanVien.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CaseStudy.Live.Controllers
{
    public class NhanVienController : Controller
    {

        public IActionResult ThongTinNhanVien(int id = 1)
        {
            var nhanvien = new NhanVienView();
            var url = $"{Common.Common.ApiUrl}/nhanvien/laynhanvientheoid/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                nhanvien = JsonConvert.DeserializeObject<NhanVienView>(responseData);

            }
            return View(nhanvien);
        }



        [HttpGet]
        public IActionResult ThongKeNhanVien(int id)
        {
            var thongke = new List<ThongKe>();
            var url = $"{Common.Common.ApiUrl}/nhanvien/thongkenhanvien/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                thongke = JsonConvert.DeserializeObject<List<ThongKe>>(responseData);
            }
            return View(thongke);
        }

        [HttpGet]
        public IActionResult ChiTietDiemDanhNhanVien(int id, int nam, int thang)
        {
            var diemdanhs = new List<DiemDanh>();
            var model = new ThongKeModel()
            {
                Id = id,
                Nam = nam,
                Thang = thang
            };
            var url = $"{Common.Common.ApiUrl}/nhanvien/chitietdiemdanhnhanvien";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var StreamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = StreamReader.ReadToEnd();
                diemdanhs = JsonConvert.DeserializeObject<List<DiemDanh>>(result);
            }
            return View(diemdanhs);
        }

        [HttpGet]
        public IActionResult XemDonXinPhep(int id)
        {
            var donxinpheps = new List<DonXinPhepView>();
            var url = $"{Common.Common.ApiUrl}/nhanvien/xemdonxinphep/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream)?.Dispose();
                }
                donxinpheps = JsonConvert.DeserializeObject<List<DonXinPhepView>>(responseData);
            }
            return View(donxinpheps);
        }

        [HttpGet]
        public IActionResult TaoDonXinPhep(int id)
        {
            var donxinphep = new DonXinPhepCreate();
            var url = $"{Common.Common.ApiUrl}/nhanvien/xemthongtintaodonxinphep/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream)?.Dispose();
                }
                donxinphep = JsonConvert.DeserializeObject<DonXinPhepCreate>(responseData);
            }
            return View(donxinphep);
        }

        [HttpPost]
        public IActionResult TaoDonXinPhep(DonXinPhepCreate model)
        {
            int createResult;
            var url = $"{Common.Common.ApiUrl}/nhanvien/taodonxinphep";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                createResult = JsonConvert.DeserializeObject<int>(result);
            }
            if (createResult > 0)
            {
                TempData["Success"] = "Đơn Xin Phép Đã Được Thêm";
            }
            else
            {
                TempData["Success"] = "Có lỗi ! Vui lòng thử lại";
            }
            ModelState.Clear();
            return RedirectToAction("ThongTinNhanVien", "NhanVien");
        }

        public IActionResult ChiTietDonXinPhep(int id)
        {
            var donxinphep = new DonXinPhepView();
            var url = $"{Common.Common.ApiUrl}/nhanvien/chitietdonxinphep/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream)?.Dispose();
                }
                donxinphep = JsonConvert.DeserializeObject<DonXinPhepView>(responseData);
            }
            return View(donxinphep);
        }
    }
}
