using CaseStudy.BAL.Interface;
using CaseStudy.DAL.Interface;
using CaseStudy.Domain.Request.NhanVien;
using CaseStudy.Domain.Response.NhanVien;
using System.Collections.Generic;

namespace CaseStudy.BAL
{
    public class NhanVienService : INhanVienService
    {
        INhanVienRepository _nhanVienRepository;
        public NhanVienService(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        public IList<DiemDanh> ChiTietDiemDanhTheoThang(ThongKeModel model)
        {
            return _nhanVienRepository.ChiTietDiemDanhTheoThang(model);
        }

        public DonXinPhepView ChiTietDonXinPhep(int id)
        {
            return _nhanVienRepository.ChiTietDonXinPhep(id);
        }

        public IList<DonXinPhepView> ChiTietDonXinPhepNhanVienTheoId(int nvId)
        {
            return _nhanVienRepository.ChiTietDonXinPhepNhanVienTheoId(nvId);
        }

        public NhanVienView LayNhanVienTheoId(int nvId)
        {
            return _nhanVienRepository.LayNhanVienTheoId(nvId);
        }

        public DonXinPhepCreate LayThongTinDonXinPhepTheoId(int nvId)
        {
            return _nhanVienRepository.LayThongTinDonXinPhepTheoId(nvId);
        }

        public int TaoDonXinPhep(DonXinPhepCreate model)
        {
            return _nhanVienRepository.TaoDonXinPhep(model);
        }

        public IList<ThongKe> ThongKeNhanVienTheoId(int nvId)
        {
            return _nhanVienRepository.ThongKeNhanVienTheoId(nvId);
        }
    }
}
