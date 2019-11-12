using System;

namespace CaseStudy.Domain.Request.NhanSu
{
    public class ThemNhanVien
    {
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
        public int QuyenId { get; set; }
        public int ChucVuId { get; set; }
        public int BoPhanId { get; set; }
        public string MatKhau { get; set; }
    }
}
