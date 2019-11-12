using System;

namespace CaseStudy.Domain.Response.QuanLy
{
    public class DonXinPhep
    {
        public int DonXinPhepId { get; set; }
        public int NhanVienId { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int TinhTrang { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoPhepConLai { get; set; }
        public int SoNgayDaNghi { get; set; }
        public DateTime NgayGui { get; set; }
        public DateTime? NgayPhanHoi { get; set; }
        public string GhiChu { get; set; }
        public string TraLoi { get; set; }
        public int QuanLyId { get; set; }
        public string Email { get; set; }
    }
}
