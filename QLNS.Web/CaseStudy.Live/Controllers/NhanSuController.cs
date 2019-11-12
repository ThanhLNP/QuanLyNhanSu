using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Live.Models.NhanSu.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using CaseStudy.Live.Models.NhanSu.Request;
using Microsoft.AspNetCore.Hosting;

namespace CaseStudy.Live.Controllers
{
    public class NhanSuController : Controller
    {
        public static int id_BackSee;
        IHostingEnvironment _env;
        private string _dir;
        private static int Id_PhongBan;
        public NhanSuController(IHostingEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
          
        }
        [HttpGet]
        public IActionResult ThongKe(int id)
        {
            var danhSach = new List<ThongKeNhanVien>();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/thongke/" + id);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
               danhSach  = JsonConvert.DeserializeObject<List<ThongKeNhanVien>>(responseData);
            }
            return View(danhSach);
        }
        [HttpGet]
        public IActionResult CapPhepNam(int id)
        {
            var phepNam = new List<ThongTinPhepNamView>();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/thongtinphepnam/" + id);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                phepNam = JsonConvert.DeserializeObject<List<ThongTinPhepNamView>>(responseData);
            }
            return View(phepNam);
        }
        [HttpPost]
        public IActionResult CapPhep(ThongTinPhepNamView phepNam)
        {
            var createResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/capphepnam");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(phepNam);
                streamWriter.Write(json);
            }
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                createResult = bool.Parse(result);
            }
            if (createResult)
            {
                TempData["Success"] = "   successfully";
            }
            else 
            {
                TempData["Error"] = "   Please Try Again";
            }
            return View(new ThongTinPhepNamView());
        }
        [HttpGet]
        public IActionResult CapPhep(int id)
        {
            var phepNam = new ThongTinPhepNamView();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/getphepnam/" + id);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                phepNam = JsonConvert.DeserializeObject<ThongTinPhepNamView>(responseData);
            }
            return View(phepNam);
        }
        public IActionResult Index()
        {
            var dsPhongBan = new List<DanhSachBoPhanViewModel>();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/danhsachbophan");
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                dsPhongBan = JsonConvert.DeserializeObject<List<DanhSachBoPhanViewModel>>(responseData);
            }
            return View(dsPhongBan);
        }
        public IActionResult See(int id)
        {
            id_BackSee = id;
            var dsNhanVien = new List<DanhSachNhanVienTheoPhongBan>();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/danhsachnhanvientheobophan/" +id);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                dsNhanVien = JsonConvert.DeserializeObject<List<DanhSachNhanVienTheoPhongBan>>(responseData);
            }
            Id_PhongBan = id;
            return View(dsNhanVien);
        }
        public IActionResult SuaThongTinNhanVien(int id)
        {
            var nhanvien = new SuaThongTinNhanVien();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/thongtinnhanvien/" + id);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                nhanvien = JsonConvert.DeserializeObject<SuaThongTinNhanVien>(responseData);
            }
            ViewBag.ChucVu = ChucVuViewBag();
            ViewBag.BoPhan = BoPhanViewBag();
            ViewBag.QuyenTruyCap = QuyenTruyCapViewBags();
            return View(nhanvien);
        }
        [HttpPost]
        public IActionResult SuaThongTinNhanVien(SuaThongTinNhanVien suaThongTin)
           {
            var updateResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/suathongtinnhanvien");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(suaThongTin);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                updateResult = bool.Parse(result);
            }
            if (updateResult)
            {
                TempData["Success"] = " update successfully";
            }
            else
            {
                 TempData["Error"] = "  Update fail , please try again !";
            }
            ViewBag.ChucVu = ChucVuViewBag();
            ViewBag.BoPhan = BoPhanViewBag();
            ViewBag.QuyenTruyCap = QuyenTruyCapViewBags();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult XoaNhanVien(int id)
        {
            var updateResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/xoanhanvien/" + id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(id);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                updateResult = bool.Parse(result);
            }
            if (updateResult)
            {
                TempData["Success"] = " delete successfully";
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ThemNhanVien()
        {
            ViewBag.ChucVu = ChucVuViewBag();
            ViewBag.BoPhan = BoPhanViewBag();
            ViewBag.QuyenTruyCap = QuyenTruyCapViewBags();
            return View();
        }
      
        [HttpPost]
        public IActionResult ThemNhanVien(ThemNhanVien nhanVien)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    var upload = Path.Combine(_dir, "wwwroot\\Upload\\Images");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            nhanVien.HinhAnh = $"{fileName}";
                        }
                    }
                }
            }
            var createResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/themnhanvien");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(nhanVien);
                streamWriter.Write(json);
            }
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                createResult = bool.Parse(result);
            }
            if (createResult)
            {
                TempData["Success"] = "  created successfully";
            }
            else
            {
                TempData["Error"] = "  create fail , please try again !";
            }
            ViewBag.ChucVu = ChucVuViewBag();
            ViewBag.BoPhan = BoPhanViewBag();
            ViewBag.QuyenTruyCap = QuyenTruyCapViewBags();
            ModelState.Clear();
  
            return View(new ThemNhanVien());
        }
        public IActionResult ThemBoPhan()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThemBoPhan(ThemBoPhan boPhan)
        {
            var createResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/thembophan");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(boPhan);
                streamWriter.Write(json);
            }
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                createResult = bool.Parse(result);
            }
            if (createResult)
            {
                TempData["Success"] = "  created successfully";
            }
            else
            {
                TempData["Error"] = "  create fail , please try again !";
            }

            return View(new ThemBoPhan());
        }
        public IActionResult SuaBoPhan(int id)
        {
            var boPhan = new SuaBoPhan();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/thongtinbophan/" + id);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                boPhan = JsonConvert.DeserializeObject<SuaBoPhan>(responseData);
            }
            
            return View(boPhan);
        }
        [HttpPost]
        public IActionResult SuaBoPhan(SuaBoPhan boPhan)
        {
            var updateResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/suabophan");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(boPhan);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                updateResult = bool.Parse(result);
            }
            if (updateResult)
            {
                TempData["Success"] = " update successfully";
            }
            else
            {
                TempData["Error"] = "  update fail , please try again !";
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult XoaBoPhan(int id)
        {
            var deleteResult = false;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/xoabophan/" + id);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(id);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                deleteResult = bool.Parse(result);
            }
            if (deleteResult)
            {
                TempData["Success"] = " delete successfully";
            }
            return RedirectToAction(nameof(Index));
        }
        private List<DanhSachBoPhanViewBag> BoPhanViewBag()
        {
            var boPhan = new List<DanhSachBoPhanViewBag>();
            var httpWedRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/laybophan");
            httpWedRequest.Method = "GET";
            var response = httpWedRequest.GetResponse();
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
                boPhan = JsonConvert.DeserializeObject<List<DanhSachBoPhanViewBag>>(responseData);
            }
            return boPhan;
        }
        private List<DanhSachChucVuViewBag> ChucVuViewBag()
        {
            var chucVu = new List<DanhSachChucVuViewBag>();
            var httpWedRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/laychucvu");
            httpWedRequest.Method = "GET";
            var response = httpWedRequest.GetResponse();
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
                chucVu = JsonConvert.DeserializeObject<List<DanhSachChucVuViewBag>>(responseData);
            }
            return chucVu;
        }
        private List<DanhSachQuyenTruyCapViewBag> QuyenTruyCapViewBags()
        {
            var quyenTruyCap = new List<DanhSachQuyenTruyCapViewBag>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/layquyentruycap");
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
                quyenTruyCap = JsonConvert.DeserializeObject<List<DanhSachQuyenTruyCapViewBag>>(responseData);
            }
            return quyenTruyCap;    

        }
        public IActionResult ThongTinBoPhan(int id)
        {
            var boPhan = new ThongTinBoPhanTheoId();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/thongtinbophan/" + id);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                boPhan = JsonConvert.DeserializeObject<ThongTinBoPhanTheoId>(responseData);
            }

            return View(boPhan);
        }
        [HttpPost]
        public IActionResult TimKiem(string search)
        {
            int id = Id_PhongBan; 
            var dsNhanVien = new List<TimKiemNhanVien>();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhansu/timkiem/" + search+ "/"+ id);
            httpWebRequest.Method = "POST";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream stream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(stream);
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
                    ((IDisposable)stream).Dispose();
                }
                dsNhanVien = JsonConvert.DeserializeObject<List<TimKiemNhanVien>>(responseData);
                
            }
            return View(dsNhanVien);
        }
    }
}