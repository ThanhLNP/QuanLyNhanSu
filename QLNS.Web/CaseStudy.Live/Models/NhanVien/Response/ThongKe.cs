using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Live.Models.NhanVien.Response
{
    public class ThongKe
    {
        public int Id { get; set; }
        [Display(Name ="Họ Tên")]
        public string HoTen { get; set; }
        public int NhanVienId { get; set; }

        [Display(Name = "Tháng")]
        public int Thang { get; set; }

        [Display(Name = "Năm")]
        public int Nam { get; set; }

        [Display(Name = "Có Mặt")]
        public int CoMat { get; set; }

        [Display(Name = "Trễ")]
        public int Tre { get; set; }

        [Display(Name = "Không Phép")]
        public int KhongPhep { get; set; }

        [Display(Name = "Có Phép")]
        public int CoPhep { get; set; }

        [Display(Name = "Theo Quy Định")]
        public int TheoQuyDinh { get; set; }

        [Display(Name = "Số Phép Còn Lại")]
        public int SoPhepConLai { get; set; }
    }
}
