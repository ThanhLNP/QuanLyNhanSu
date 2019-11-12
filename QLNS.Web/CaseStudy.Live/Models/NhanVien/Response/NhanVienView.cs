using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Live.Models.NhanVien.Response
{
    public class NhanVienView
    {
        public int Id { get; set; }
        [Display(Name ="Họ tên:")]
        public string HoTen { get; set; }
        [Display(Name = "Giới Tính:")]
        public string GioiTinh { get; set; }


        [Display(Name = "Ngày Sinh:")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Số Chứng Minh:")]
        public string SoChungMinh { get; set; }
        [Display(Name ="Số Điện Thoại")]
        [Phone(ErrorMessage ="Nhập đúng số điện thoại.")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage ="Nhập đúng email")]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ:")]
        public string DiaChi { get; set; }
        [Display(Name = "Mã Số Thuế:")]
        public string MaSoThue { get; set; }
        [Display(Name = "Hình Ảnh:")]
        public string HinhAnh { get; set; }
        [Display(Name ="Bộ Phận")]
        public string BoPhan { get; set; }
        [Display(Name = "CHức Vụ")]
        public string ChucVu { get; set; }
    }
}
