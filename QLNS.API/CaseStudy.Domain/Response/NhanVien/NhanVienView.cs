using System;

namespace CaseStudy.Domain.Response.NhanVien
{
    public class NhanVienView
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoChungMinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string HinhAnh { get; set; }
        public string BoPhan { get; set; }
        public string ChucVu { get; set; }
    }
}
