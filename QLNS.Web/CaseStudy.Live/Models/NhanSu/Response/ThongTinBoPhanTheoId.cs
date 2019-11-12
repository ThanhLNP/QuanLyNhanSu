using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Response
{
    public class ThongTinBoPhanTheoId
    {
        public int Id { get; set; }
        [Display(Name ="Tên Bộ Phận")]
        public string Ten { get; set; }
       
        public bool DangHoatDong { get; set; }
        [Display(Name = "Trạng Thái")]
        public string DangHoatDongStr => DangHoatDong ? "Đang Hoạt Động" : "Ngưng Hoạt Động";
        [Display(Name = "Số Lượng Nhân Viên")]
        public int SoLuong { get; set; }
    }
}
