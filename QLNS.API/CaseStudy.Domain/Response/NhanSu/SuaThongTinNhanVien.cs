using System;

namespace CaseStudy.Domain.Response.NhanSu
{
    public  class SuaThongTinNhanVien
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
        public int QuyenId { get; set; }
        public int ChucVuId { get; set; }
        public int BoPhanId { get; set; }
   
    }
}
//@Id INT
//      , @Ho NVARCHAR(50)
//      ,@Ten NVARCHAR(50)
//      ,@GioiTinh BIT
//      , @NgaySinh DATE
//      ,@SoChungMinh NVARCHAR(50)
//      ,@SoDienThoai NVARCHAR(50)
//      ,@Email NVARCHAR(100)
//      ,@DiaChi NVARCHAR(500)
//      ,@MaSoThue NVARCHAR(50)
//      ,@HinhAnh NVARCHAR(MAX)
//      ,@NgayTao DATE
//      , @NgaySua DATE
//      ,@DangLamViec BIT
//      , @DaXoa BIT)
