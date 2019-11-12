using System;

namespace CaseStudy.Domain.Request.QuanLy
{
    public class LayDiemDanhNhanVienId : BaseRequest
    {
        public int NhanVienId { get; set; }
        public DateTime Ngay { get; set; }
    }
}
