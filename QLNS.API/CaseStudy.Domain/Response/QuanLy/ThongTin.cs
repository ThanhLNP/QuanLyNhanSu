using System;

namespace CaseStudy.Domain.Response.QuanLy
{
    public class ThongTin
    {
        public int NhanVienId { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string HinhAnh { get; set; }
        public string ChucVuTen { get; set; }
    }
}
