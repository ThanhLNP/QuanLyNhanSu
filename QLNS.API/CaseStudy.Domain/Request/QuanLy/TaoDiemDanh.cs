using System;

namespace CaseStudy.Domain.Request.QuanLy
{
    public class TaoDiemDanh : BaseRequest
    {
        public int NhanVienId { get; set; }
        public int TrangThai { get; set; }
        public DateTime Ngay { get; set; }
    }
}
