using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Response
{
    public class ThongTinPhepNamView
    {
        public int NhanVienId { get; set; }
        [Display(Name ="Năm")]
        public int Nam { get; set; }
        [Display(Name ="Số Ngày Phép")]
        public int SoPhep { get; set; }
    }
}
