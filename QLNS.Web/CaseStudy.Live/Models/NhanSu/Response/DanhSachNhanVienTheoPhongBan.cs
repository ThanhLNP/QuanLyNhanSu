using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Response
{
    public class DanhSachNhanVienTheoPhongBan
    {
        public int Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        [Display(Name = "SĐT")]
        public string SoDienThoai { get; set; }
        [Display(Name = "Giới Tính")]
        public string GioiTinhStr => GioiTinh ? "Nam" : "Nữ";
        [Display(Name ="Họ Tên")]
        public string HoTen => Ho +" "+ Ten;
    }
}
