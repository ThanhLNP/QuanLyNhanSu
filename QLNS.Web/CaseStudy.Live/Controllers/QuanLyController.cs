using CaseStudy.Live.Models.QuanLy.Request;
using CaseStudy.Live.Models.QuanLy.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CaseStudy.Live.Controllers
{
    public class QuanLyController : Controller
    {
        #region Method
        public string GetMethod(string url, object model)
        {
            string responseData;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }

            WebResponse response = httpWebRequest.GetResponse();
            {
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
            }

            return responseData;
        }

        public bool PostMethod(string url, object model)
        {
            var createResult = false;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                createResult = bool.Parse(result);
            }

            return createResult;
        }
        #endregion

        #region View Bag
        private List<string> LayTrangThaiList()
        {
            List<string> trangThaiList = new List<string>()
            {
            "Có mặt",
            "Đi trễ",
            "Vắng không phép",
            "Vắng có phép",
            "Nghỉ không lương"
            };
            return trangThaiList;
        }

        private List<string> LayTinhTrangList()
        {
            List<string> tinhTrangList = new List<string>()
            {
            "Chờ",
            "Chấp nhận",
            "Từ chối"
            };
            return tinhTrangList;
        }
        #endregion

        #region Diem Danh
        [HttpGet]
        public IActionResult DiemDanhBoPhan(LayDiemDanhBoPhanId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayDiemDanhBoPhanId";
            var responseData = GetMethod(url, model);

            var diemDanh = new List<DiemDanh>();
            diemDanh = JsonConvert.DeserializeObject<List<DiemDanh>>(responseData);

            return View(diemDanh);
        }

        [HttpGet]
        public IActionResult DiemDanhNhanVien(LayDiemDanhNhanVienId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayDiemDanhNhanVienId";
            var responseData = GetMethod(url, model);

            var diemDanh = new DiemDanh();
            diemDanh = JsonConvert.DeserializeObject<DiemDanh>(responseData);

            return View(diemDanh);
        }

        [HttpPost]
        public IActionResult DiemDanhBoPhanAjax([FromBody] LayDiemDanhBoPhanId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayDiemDanhBoPhanId";
            var responseData = GetMethod(url, model);

            var diemDanh = new List<DiemDanh>();
            diemDanh = JsonConvert.DeserializeObject<List<DiemDanh>>(responseData);

            return Json(new { response = diemDanh, code = 1 });
        }

        [HttpPost]
        public IActionResult DiemDanhNhanVienAjax([FromBody] LayDiemDanhNhanVienId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayDiemDanhNhanVienId";
            var responseData = GetMethod(url, model);

            var diemDanh = new DiemDanh();
            diemDanh = JsonConvert.DeserializeObject<DiemDanh>(responseData);

            return Json(new { response = diemDanh, code = 1 });
        }

        [HttpPost]
        public IActionResult TaoDiemDanhNhanVien(TaoDiemDanh model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/TaoDiemDanh";
            var createResult = PostMethod(url, model);

            return RedirectToAction("DiemDanhNhanVien", "QuanLy", new LayDiemDanhNhanVienId { NhanVienId = model.NhanVienId, Ngay = model.Ngay });
        }
        #endregion

        #region Thong Ke
        [HttpGet]
        public IActionResult ChiTietDiemDanh(LayDiemDanhNhanVienIdThang model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayDiemDanhNhanVienIdThang";
            var responseData = GetMethod(url, model);

            var diemDanh = new List<DiemDanh>();
            diemDanh = JsonConvert.DeserializeObject<List<DiemDanh>>(responseData);

            ViewBag.TrangThaiList = LayTrangThaiList();
            return View(diemDanh);
        }

        [HttpGet]
        public IActionResult ThongKeBoPhan(LayThongKeBoPhanId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayThongKeBoPhanId";
            var responseData = GetMethod(url, model);

            List<ThongKe> thongKe = new List<ThongKe>();
            thongKe = JsonConvert.DeserializeObject<List<ThongKe>>(responseData);
            return View(thongKe);
        }

        [HttpGet]
        public IActionResult ThongKeNhanVien(LayThongKeNhanVienId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayThongKeNhanVienId";
            var responseData = GetMethod(url, model);

            List<ThongKe> thongKe = new List<ThongKe>();
            thongKe = JsonConvert.DeserializeObject<List<ThongKe>>(responseData);
            return View(thongKe);
        }
        #endregion

        #region Don Xin Phep
        [HttpGet]
        public IActionResult DanhSachDonXinPhep(LayDonXinPhepBoPhanId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayDonXinPhepBoPhanId";
            var responseData = GetMethod(url, model);

            List<DonXinPhep> donXinPhep = new List<DonXinPhep>();
            donXinPhep = JsonConvert.DeserializeObject<List<DonXinPhep>>(responseData);

            ViewBag.TinhTrangList = LayTinhTrangList();
            return View(donXinPhep);
        }

        [HttpGet]
        public IActionResult DonXinPhep(LayDonXinPhepNhanVienId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayDonXinPhepNhanVienId";
            var responseData = GetMethod(url, model);

            DonXinPhep donXinPhep = new DonXinPhep();
            donXinPhep = JsonConvert.DeserializeObject<DonXinPhep>(responseData);

            ViewBag.TinhTrangList = LayTinhTrangList();
            return View(donXinPhep);
        }

        [HttpPost]
        public IActionResult SuaDonXinPhepNhanVien(SuaDonXinPhepNhanVienId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/SuaDonXinPhepNhanVienId";
            var createResult = PostMethod(url, model);

            return RedirectToAction("DanhSachDonXinPhep", "QuanLy", new LayDonXinPhepBoPhanId { });
        }
        #endregion

        #region Thong Tin
        [HttpGet]
        public IActionResult ThongTin(LayThongTinBoPhanId model)
        {
            var url = $"{Common.Common.ApiUrl}/quanly/LayThongTinBoPhanId";
            var responseData = GetMethod(url, model);

            List<ThongTin> thongTin = new List<ThongTin>();
            thongTin = JsonConvert.DeserializeObject<List<ThongTin>>(responseData);
            return View(thongTin);
        }
        #endregion
    }
}