using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Live.Models.NhanVien.Response
{
    public class DiemDanh
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }


        [Display(Name ="Trạng Thái")]
        public string TrangThai { get; set; }

        [Display(Name ="Ngày Tháng")]
        public string Ngay { get; set; }
    }
}
