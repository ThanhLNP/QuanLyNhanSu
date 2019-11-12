using CaseStudy.Domain.Request.NhanSu;

using CaseStudy.Domain.Response.NhanSu;


using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.DAL.Interface
{
 public   interface INhanSuRepository
    {
        IList<ThongKeNhanVien> ThongKe(int id);
        CapPhepNhanVienView GetPhepNhanVien(int id);
        IList<CapPhepNhanVienView> ThongTinPhepNam(int id);
        bool CapPhepNam(CapPhepNam phepNam);
        bool ThemBoPhan(ThemBoPhan boPhan);
        bool SuaBoPhan(SuaBoPhan boPhan);
        bool XoaBoPhan(int id);
        ThongTinBoPhanTheoId ThongTinBoPhan(int id);
        IList<DanhSachBoPhan> ThongTinBoPhan();
        IList<DanhSachNhanVienTheoPhongBan> ThongTinNhanVienTheoPhongBan(int id);
        bool SuaThongTinNhanVien(SuaThongTinNhanVien nhanVien);
        HienThiThongTinNhanVien ThongTinNhanVien(int id);
        bool XoaNhanVien(int id);
        bool ThemNhanVien(ThemNhanVien nhanVien );
        IList<BoPhanViewBag> BoPhanViewBags();
        IList<ChucVuViewBag> ChucVuViewBags();
        IList<QuyenTruyCapViewBag> QuyenTruyCapViewBags();
        IList<TimKiemNhanVien> TimKiemNhanVien(string search , int id);
    }
}
