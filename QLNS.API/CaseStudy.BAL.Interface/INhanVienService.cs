using CaseStudy.Domain.Request.NhanVien;
using CaseStudy.Domain.Response.NhanVien;
using System.Collections.Generic;

namespace CaseStudy.BAL.Interface
{
    public interface INhanVienService
    {
        NhanVienView LayNhanVienTheoId(int nvId);
        IList<ThongKe> ThongKeNhanVienTheoId(int nvId);
        IList<DiemDanh> ChiTietDiemDanhTheoThang(ThongKeModel model);

        IList<DonXinPhepView> ChiTietDonXinPhepNhanVienTheoId(int nvId);
        DonXinPhepCreate LayThongTinDonXinPhepTheoId(int nvId);
        int TaoDonXinPhep(DonXinPhepCreate model);

        DonXinPhepView ChiTietDonXinPhep(int id);
    }
}
