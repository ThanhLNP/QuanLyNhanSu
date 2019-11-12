using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.BAL.Interface;
using CaseStudy.Domain.Request.NhanSu;
using CaseStudy.Domain.Response.NhanSu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    
    [ApiController]
    public class NhanSuController : ControllerBase
    {
        private readonly INhanSuService _nhanSuService;
        public NhanSuController(INhanSuService nhanSuService)
        {
            _nhanSuService = nhanSuService;
        }
        [HttpGet]
        [Route("api/nhansu/thongke/{id}")]
        public IEnumerable<ThongKeNhanVien> ThongKe(int id)
        {
            return _nhanSuService.ThongKe(id);

        }
        [HttpGet]
        [Route("api/nhansu/getphepnam/{id}")]
        public CapPhepNhanVienView GetPhepNhanVien(int id)
        {
            return _nhanSuService.GetPhepNhanVien(id);
        }
        [HttpGet]
        [Route("api/nhansu/thongtinphepnam/{id}")]
        public IEnumerable<CapPhepNhanVienView> ThongTinPhepNam(int id)
        {
            return _nhanSuService.ThongTinPhepNam(id);
        }
        [HttpGet]
        [Route("api/nhansu/danhsachbophan")]
        public IEnumerable<DanhSachBoPhan> ThongTinBoPhan()
        {
            return _nhanSuService.ThongTinBoPhan();
        }
        [HttpPost]
        [Route("api/nhansu/thembophan")]
        public bool ThemBoPhan(ThemBoPhan boPhan)
        {
            return _nhanSuService.ThemBoPhan(boPhan);
        }
        [HttpPut]
        [Route("api/nhansu/capphepnam")]
        public bool CapPhepNam(CapPhepNam phepNam)
        {
            return _nhanSuService.CapPhepNam(phepNam);
        }
        [HttpPut]
        [Route("api/nhansu/suabophan")]
        public bool SuaBoPhan(SuaBoPhan boPhan)
        {
            return _nhanSuService.SuaBoPhan(boPhan);
        }
        [HttpDelete]
        [Route("api/nhansu/xoabophan/{id}")]
        public bool XoaBoPhan(int id)
        {
            return _nhanSuService.XoaBoPhan(id);
        }
        [HttpGet]
        [Route("api/nhansu/thongtinbophan/{id}")]
        public ThongTinBoPhanTheoId ThongTinBoPhan(int id)
        {
            return _nhanSuService.ThongTinBoPhan(id);
        }
        [HttpGet]
        [Route("api/nhansu/danhsachnhanvientheobophan/{id}")]
        public IEnumerable<DanhSachNhanVienTheoPhongBan> ThongTinNhanVienTheoPhongBan(int id)
        {  
            return _nhanSuService.ThongTinNhanVienTheoPhongBan(id);
        }
        [HttpPut]
        [Route("api/nhansu/suathongtinnhanvien")]
       public bool SuaThongTinNhanVien(SuaThongTinNhanVien nhanVien)
        {
            return _nhanSuService.SuaThongTinNhanVien(nhanVien);
        }
        [HttpGet]
        [Route("api/nhansu/thongtinnhanvien/{id}")]
        public HienThiThongTinNhanVien ThongTinNhanVien(int id)
        {
            return _nhanSuService.ThongTinNhanVien(id);
        }
        [HttpPost]
        [Route("api/nhansu/themnhanvien")]
        public bool ThemNhanVien(ThemNhanVien nhanVien)
        {
            return _nhanSuService.ThemNhanVien(nhanVien);
        }
        [HttpDelete]
        [Route("api/nhansu/xoanhanvien/{id}")]
        public bool XoaNhanVien(int id)
        {
            return _nhanSuService.XoaNhanVien(id);
        }
        [HttpGet]
        [Route("api/nhansu/laychucvu")]
        public IEnumerable<ChucVuViewBag> ChucVuViewBags()
        {
            return _nhanSuService.ChucVuViewBags();
        }
        [HttpGet]
        [Route("api/nhansu/laybophan")]
        public IEnumerable<BoPhanViewBag> BoPhanViewBags()
        {
            return _nhanSuService.BoPhanViewBags();
        }
        [HttpGet]
        [Route("api/nhansu/layquyentruycap")]
        public IEnumerable<QuyenTruyCapViewBag> QuyenTruyCapViewBags()
        {
            return _nhanSuService.QuyenTruyCapViewBags();
        }
        [HttpPost]
        [Route("api/nhansu/timkiem/{search}/{id}")]
        public IList<TimKiemNhanVien> TimKiemNhanVien(string search, int id)
        {
            return _nhanSuService.TimKiemNhanVien(search, id);
        }
    }
}