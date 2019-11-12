using System;

namespace CaseStudy.Domain.Response.QuanLy
{
    public class DiemDanh
    {
        public int NhanVienId { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int TrangThai { get; set; }
        public DateTime Ngay { get; set; }
        public int QuanLyId { get; set; }
    }
}
