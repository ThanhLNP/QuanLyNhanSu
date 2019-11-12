using System;

namespace CaseStudy.Live.Models.QuanLy.Request
{
    public class SuaDonXinPhepNhanVienId : BaseRequest
    {
        public int DonXinPhepId { get; set; }
        public int TinhTrang { get; set; }
        public string TraLoi { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime NgayPhanHoi { get; set; }
        public string Email { get; set; }
    }
}
