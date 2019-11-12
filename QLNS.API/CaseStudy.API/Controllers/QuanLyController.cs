using CaseStudy.BAL.Interface;
using CaseStudy.Domain.Request.QuanLy;
using CaseStudy.Domain.Response.QuanLy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseStudy.API.Controllers
{
    [ApiController]
    [Route("api/quanly")]
    public class QuanLyController : ControllerBase
    {
        IQuanLyService _quanLyService;
        public QuanLyController(IQuanLyService quanLyService)
        {
            _quanLyService = quanLyService;
        }

        #region Diem Danh
        [HttpPost]
        [Route("LayDiemDanhBoPhanId")]
        public IList<DiemDanh> LayDiemDanhBoPhanId(LayDiemDanhBoPhanId model)
        {
            return _quanLyService.LayDiemDanhBoPhanId(model);
        }

        [HttpPost]
        [Route("LayDiemDanhNhanVienId")]
        public DiemDanh LayDiemDanhNhanVienId(LayDiemDanhNhanVienId model)
        {
            return _quanLyService.LayDiemDanhNhanVienId(model);
        }

        [HttpPost]
        [Route("TaoDiemDanh")]
        public bool TaoDiemDanh([FromBody] TaoDiemDanh model)
        {
            return _quanLyService.TaoDiemDanh(model);
        }
        #endregion

        #region Thong Ke
        [HttpPost]
        [Route("LayDiemDanhNhanVienIdThang")]
        public IList<DiemDanh> LayDiemDanhNhanVienIdThang(LayDiemDanhNhanVienIdThang model)
        {
            return _quanLyService.LayDiemDanhNhanVienIdThang(model);
        }

        [HttpPost]
        [Route("LayThongKeBoPhanId")]
        public IList<ThongKe> LayThongKeBoPhanId(LayThongKeBoPhanId model)
        {
            return _quanLyService.LayThongKeBoPhanId(model);
        }

        [HttpPost]
        [Route("LayThongKeNhanVienId")]
        public IList<ThongKe> LayThongKeNhanVienId(LayThongKeNhanVienId model)
        {
            return _quanLyService.LayThongKeNhanVienId(model);
        }
        #endregion

        #region Don Xin Phep
        [HttpPost]
        [Route("LayDonXinPhepBoPhanId")]
        public IList<DonXinPhep> LayDonXinPhepBoPhanId(LayDonXinPhepBoPhanId model)
        {
            return _quanLyService.LayDonXinPhepBoPhanId(model);
        }

        [HttpPost]
        [Route("LayDonXinPhepNhanVienId")]
        public DonXinPhep LayDonXinPhepNhanVienId(LayDonXinPhepNhanVienId model)
        {
            return _quanLyService.LayDonXinPhepNhanVienId(model);
        }

        [HttpPost]
        [Route("SuaDonXinPhepNhanVienId")]
        public bool SuaDonXinPhepNhanVienId(SuaDonXinPhepNhanVienId model)
        {
            return _quanLyService.SuaDonXinPhepNhanVienId(model);
        }
        #endregion

        #region Thong Tin
        [HttpPost]
        [Route("LayThongTinBoPhanId")]
        public IList<ThongTin> LayThongTinBoPhanId(LayThongTinBoPhanId model)
        {
            return _quanLyService.LayThongTinBoPhanId(model);
        }
        #endregion
    }
}