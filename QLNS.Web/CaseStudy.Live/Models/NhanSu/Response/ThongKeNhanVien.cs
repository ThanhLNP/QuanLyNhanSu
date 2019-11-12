using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Response
{
    public class ThongKeNhanVien
    {
        [Display(Name ="Có Mặt")]
        public int CoMat { get; set; }
        [Display(Name = "Trể")]

        public int Tre { get; set; }
        [Display(Name = "Không Phép")]

        public int KhongPhep { get; set; }
        [Display(Name = "Có Phép")]

        public int CoPhep { get; set; }
        [Display(Name = "Theo Quy Định")]

        public int TheoQuyDinh { get; set; }
        [Display(Name = "Số Phép Còn Lại")]

        public int SoPhepConLai { get; set; }
        [Display(Name = "Tháng ")]

        public int Thang { get; set; }
        [Display(Name = "Năm")]

        public int Nam { get; set; }
    }
}
