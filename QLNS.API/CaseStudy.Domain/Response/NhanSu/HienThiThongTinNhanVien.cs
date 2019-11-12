using System;

namespace CaseStudy.Domain.Response.NhanSu
{
    public class HienThiThongTinNhanVien
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
        public DateTime NgayTao { get; set; }
        public DateTime NgaySua { get; set; }
        public bool DangLamViec { get; set; }
        public string DanglamViecStr => DangLamViec ? "Đang Làm Việc" : "Ngưng Làm Việc";
        public string GioiTinhStr => GioiTinh ? "Nam" : "Nữ";
        public int QuyenId { get; set; }
        public int ChucVuId { get; set; }
        public int BoPhanId { get; set; }

    }
}
