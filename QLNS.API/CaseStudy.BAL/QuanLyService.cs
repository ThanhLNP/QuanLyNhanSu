using CaseStudy.BAL.Interface;
using CaseStudy.DAL.Interface;
using CaseStudy.Domain.Request.QuanLy;
using CaseStudy.Domain.Response.QuanLy;
using System.Collections.Generic;

namespace CaseStudy.BAL
{
    public class QuanLyService : IQuanLyService
    {
        IQuanLyRepository _quanLyRepository;
        public QuanLyService(IQuanLyRepository quanLyRepository)
        {
            _quanLyRepository = quanLyRepository;
        }

        #region Diem Danh
        public IList<DiemDanh> LayDiemDanhBoPhanId(LayDiemDanhBoPhanId model)
        {
            return _quanLyRepository.LayDiemDanhBoPhanId(model);
        }

        public DiemDanh LayDiemDanhNhanVienId(LayDiemDanhNhanVienId model)
        {
            return _quanLyRepository.LayDiemDanhNhanVienId(model);
        }

        public bool TaoDiemDanh(TaoDiemDanh model)
        {
            return _quanLyRepository.TaoDiemDanh(model);
        }
        #endregion

        #region Thong Ke
        public IList<DiemDanh> LayDiemDanhNhanVienIdThang(LayDiemDanhNhanVienIdThang model)
        {
            return _quanLyRepository.LayDiemDanhNhanVienIdThang(model);
        }

        public IList<ThongKe> LayThongKeBoPhanId(LayThongKeBoPhanId model)
        {
            return _quanLyRepository.LayThongKeBoPhanId(model);
        }

        public IList<ThongKe> LayThongKeNhanVienId(LayThongKeNhanVienId model)
        {
            return _quanLyRepository.LayThongKeNhanVienId(model);
        }
        #endregion

        #region Don Xin Phep
        public IList<DonXinPhep> LayDonXinPhepBoPhanId(LayDonXinPhepBoPhanId model)
        {
            return _quanLyRepository.LayDonXinPhepBoPhanId(model);
        }

        public DonXinPhep LayDonXinPhepNhanVienId(LayDonXinPhepNhanVienId model)
        {
            return _quanLyRepository.LayDonXinPhepNhanVienId(model);
        }

        public bool SuaDonXinPhepNhanVienId(SuaDonXinPhepNhanVienId model)
        {
            return _quanLyRepository.SuaDonXinPhepNhanVienId(model);
        }
        #endregion

        #region Thong Tin
        public IList<ThongTin> LayThongTinBoPhanId(LayThongTinBoPhanId model)
        {
            return _quanLyRepository.LayThongTinBoPhanId(model);
        }
        #endregion
    }
}
