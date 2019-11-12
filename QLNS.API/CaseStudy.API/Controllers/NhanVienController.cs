using CaseStudy.BAL.Interface;
using CaseStudy.Domain.Request.NhanVien;
using CaseStudy.Domain.Response.NhanVien;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseStudy.API.Controllers
{

    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;
        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }
        // GET api/values

        [HttpGet]
        [Route("api/nhanvien/laynhanvientheoid/{id}")]
        public NhanVienView LayNhanVienTheoId(int id)
        {
            return _nhanVienService.LayNhanVienTheoId(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/nhanvien/thongkenhanvien/{id}")]
        public IEnumerable<ThongKe> ThongKeNhanVienTheoId(int id)
        {
            return _nhanVienService.ThongKeNhanVienTheoId(id);
        }

        [HttpPost]
        [Route("api/nhanvien/chitietdiemdanhnhanvien")]
        public IEnumerable<DiemDanh> ChiTietDiemDanh(ThongKeModel model)
        {
            return _nhanVienService.ChiTietDiemDanhTheoThang(model);
        }

        [HttpGet]
        [Route("api/nhanvien/xemdonxinphep/{id}")]
        public IEnumerable<DonXinPhepView> XemDonXinPhep(int id)
        {
            return _nhanVienService.ChiTietDonXinPhepNhanVienTheoId(id);
        }

        [HttpGet]
        [Route("api/nhanvien/xemthongtintaodonxinphep/{id}")]
        public DonXinPhepCreate TaoDonXinPhepTheoId(int id)
        {
            return _nhanVienService.LayThongTinDonXinPhepTheoId(id);
        }
        [HttpPost]
        [Route("api/nhanvien/taodonxinphep")]
        public int TaoDonXinPhep([FromBody] DonXinPhepCreate request)
        {
            return _nhanVienService.TaoDonXinPhep(request);
        }
        

        [HttpGet]
        [Route("api/nhanvien/chitietdonxinphep/{id}")]
        public DonXinPhepView ChiTietDonXinPhep(int id)
        {
            return _nhanVienService.ChiTietDonXinPhep(id);
        }
    }
}
