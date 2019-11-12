using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Live.Models.NhanSu.Request
{
    public class SuaThongTinNhanVien
    {
        public int Id { get; set; }
        [Display(Name="Họ")]
        [StringLength(50)]
        [Required]
        public string Ho { get; set; }
        [Display(Name = "Tên")]
        [StringLength(50)]
        [Required]
        public string Ten { get; set; }
        [Display(Name = "Giới Tính")]
        public bool GioiTinh { get; set; }
        [Display(Name = "Ngày Sinh")]
        //[Remote("CheckDateTime", "NhanSu")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Số Chứng Minh")]
        [StringLength(10)]
        public string SoChungMinh { get; set; }
        [Display(Name = "Số Điện Thoại")]
        [Phone]
        //[RegularExpression(@"/^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)? (\d{3})$/)")]
        public string SoDienThoai { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Địa Chỉ")]
        [Required]
        [StringLength(160)]
        public string DiaChi { get; set; }
        [Display(Name = "Mã Số Thuế")]
        [StringLength(50)]
        public string MaSoThue { get; set; }
        [Display(Name = "Hình Anh")]
        public string HinhAnh { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayTao { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgaySua { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool DangLamViec { get; set; }
        [Display(Name = "Quyền Truy Cập")]
        public int QuyenId { get; set; }
        [Display(Name = "Chức Vụ")]
        public int ChucVuId { get; set; }
        [Display(Name = "Bộ Phận")]
        public int BoPhanId { get; set; }
       
    }
}
