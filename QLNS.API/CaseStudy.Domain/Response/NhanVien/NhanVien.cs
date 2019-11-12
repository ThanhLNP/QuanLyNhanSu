using System;

namespace CaseStudy.Domain.Response.NhanVien
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoChungMinh { get; set; }
        public string SoDienThoai { get; set; }

        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string HinhAnh { get; set; }
    }
}
