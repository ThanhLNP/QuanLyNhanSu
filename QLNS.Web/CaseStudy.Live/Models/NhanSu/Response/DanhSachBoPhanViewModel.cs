using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Response
{
    public class DanhSachBoPhanViewModel
    {
        [Display(Name ="#ID")]
        public int Id { get; set; }
        [Display(Name ="Tên Bộ Phận")]
        public string Ten { get; set; }
        [Display(Name ="Số Lượng Nhân Viên")]
        public int SoLuong { get; set; }
    }
}
