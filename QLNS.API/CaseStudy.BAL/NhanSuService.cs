using CaseStudy.BAL.Interface;
using CaseStudy.DAL.Interface;
using CaseStudy.Domain.Request.NhanSu;
using CaseStudy.Domain.Response.NhanSu;
using System.Collections.Generic;

namespace CaseStudy.BAL
{
    public class NhanSuService : INhanSuService
    {
        protected INhanSuRepository _nhanSuRepo;
      
        public NhanSuService(INhanSuRepository nhanSuRepository)
        {
            _nhanSuRepo = nhanSuRepository;
        }
        public IList<ThongKeNhanVien> ThongKe(int id)
        {
            return _nhanSuRepo.ThongKe(id);
        }
        public CapPhepNhanVienView GetPhepNhanVien(int id)
        {
            return _nhanSuRepo.GetPhepNhanVien(id);
        }
        public IList<CapPhepNhanVienView> ThongTinPhepNam(int id)
        {
            return _nhanSuRepo.ThongTinPhepNam(id);
        }
        public bool CapPhepNam(CapPhepNam phepNam)
        {
            return _nhanSuRepo.CapPhepNam(phepNam);
        }
        public bool ThemBoPhan(ThemBoPhan boPhan)
        {
            return _nhanSuRepo.ThemBoPhan(boPhan);
        }
        public bool SuaBoPhan(SuaBoPhan boPhan)
        {
            return _nhanSuRepo.SuaBoPhan(boPhan);
        }
        public bool XoaBoPhan(int id)
        {
            return _nhanSuRepo.XoaBoPhan(id);
        }
        public ThongTinBoPhanTheoId ThongTinBoPhan(int id)
        {
            return _nhanSuRepo.ThongTinBoPhan(id);
        }
        public IList<DanhSachBoPhan> ThongTinBoPhan()
        {
            return _nhanSuRepo.ThongTinBoPhan();
        }
        public IList<DanhSachNhanVienTheoPhongBan> ThongTinNhanVienTheoPhongBan(int id)
        {
           return _nhanSuRepo.ThongTinNhanVienTheoPhongBan(id);    
        }
        public bool SuaThongTinNhanVien(SuaThongTinNhanVien nhanVien)
        {
            return _nhanSuRepo.SuaThongTinNhanVien(nhanVien);
        }
        public HienThiThongTinNhanVien ThongTinNhanVien(int id)
        {
            return _nhanSuRepo.ThongTinNhanVien(id);
        }
        public bool XoaNhanVien(int id)
        {
            return _nhanSuRepo.XoaNhanVien(id);
        }
        public bool ThemNhanVien(ThemNhanVien nhanVien)
        {
            return _nhanSuRepo.ThemNhanVien(nhanVien);
        }
        public IList<BoPhanViewBag> BoPhanViewBags()
        {
            return _nhanSuRepo.BoPhanViewBags();
        }
        public IList<ChucVuViewBag> ChucVuViewBags()
        {
            return _nhanSuRepo.ChucVuViewBags();
        }
        public IList<QuyenTruyCapViewBag> QuyenTruyCapViewBags()
        {
            return _nhanSuRepo.QuyenTruyCapViewBags();
        }
        public IList<TimKiemNhanVien> TimKiemNhanVien(string search, int id)
        {
            return _nhanSuRepo.TimKiemNhanVien(search, id);
        }
    }
}
