using System;

namespace CaseStudy.Live.Models.QuanLy.Request
{
    public class TaoDiemDanh : BaseRequest
    {
        public int NhanVienId { get; set; }
        public int TrangThai { get; set; }
        public DateTime Ngay { get; set; }
    }
}
