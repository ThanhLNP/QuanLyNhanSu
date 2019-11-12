using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Request
{
    public class ThemNhanVien
    {
        [Required]
        [Display(Name ="Họ")]
        [StringLength(50)]
        public string Ho { get; set; }
        [Required]
        [Display(Name ="Tên")]
        [StringLength(50)]
        public string Ten { get; set; }
        [Required]
        [Display(Name = "Gioi Tính")]
        public bool GioiTinh { get; set; }
        [Required]
        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Required]
        [Display(Name = "Số Chứng Minh")]
        [StringLength(10)]
        public string SoChungMinh { get; set; }
        [Required]
        [Display(Name = "Số Điện Thoại")]
        [Phone(ErrorMessage ="Nhập đúng số điện thoại")]
        //[RegularExpression(@"/^(0|\+84)(\s|\.)?((3[2-9])|(5[689])|(7[06-9])|(8[1-689])|(9[0-46-9]))(\d)(\s|\.)?(\d{3})(\s|\.)? (\d{3})$/)")]
        public string SoDienThoai { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Địa Chỉ")]
        [StringLength(160)]
        public string DiaChi { get; set; }
        [Required]
        [Display(Name = "Mã Số Thuế")]
        [StringLength(50)]
        public string MaSoThue { get; set; }
       
        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
        [Required]
        [Display(Name = "Quyền Truy Cập")]
        public int QuyenId { get; set; }
        [Required]
        [Display(Name = "Chức Vụ")]
        public int ChucVuId { get; set; }
        [Required]
        [Display(Name = "Bộ Phận")]
        public int BoPhanId { get; set; }
        [Required]
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }
    }
}
