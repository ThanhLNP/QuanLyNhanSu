using CaseStudy.Domain.Request.QuanLy;
using CaseStudy.Domain.Response.QuanLy;
using System.Collections.Generic;

namespace CaseStudy.DAL.Interface
{
    public interface IQuanLyRepository
    {
        #region Diem Danh
        IList<DiemDanh> LayDiemDanhBoPhanId(LayDiemDanhBoPhanId model);
        DiemDanh LayDiemDanhNhanVienId(LayDiemDanhNhanVienId model);
        bool TaoDiemDanh(TaoDiemDanh model);
        #endregion

        #region Thong Ke
        IList<DiemDanh> LayDiemDanhNhanVienIdThang(LayDiemDanhNhanVienIdThang model);
        IList<ThongKe> LayThongKeBoPhanId(LayThongKeBoPhanId model);
        IList<ThongKe> LayThongKeNhanVienId(LayThongKeNhanVienId model);
        #endregion

        #region Don Xin Phep
        IList<DonXinPhep> LayDonXinPhepBoPhanId(LayDonXinPhepBoPhanId model);
        DonXinPhep LayDonXinPhepNhanVienId(LayDonXinPhepNhanVienId model);
        bool SuaDonXinPhepNhanVienId(SuaDonXinPhepNhanVienId model);
        #endregion

        #region Thong Tin
        IList<ThongTin> LayThongTinBoPhanId(LayThongTinBoPhanId model);
        #endregion
    }
}
