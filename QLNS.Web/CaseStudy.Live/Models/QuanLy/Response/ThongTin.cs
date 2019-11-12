using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.QuanLy.Response
{
    public class ThongTin
    {
        public int NhanVienId { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }

        [Display(Name = "Họ và tên")]
        public string HoTen => Ho + " " + Ten;

        public bool GioiTinh { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinhStr => GioiTinh ? "Nam" : "Nữ";

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        public string Email { get; set; }
        public string HinhAnh { get; set; }

        [Display(Name = "Chức vụ")]
        public string ChucVuTen { get; set; }
    }
}
