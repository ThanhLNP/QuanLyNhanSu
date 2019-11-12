using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.QuanLy.Response
{
    public class ThongKe
    {
        public int NhanVienId { get; set; }

        [Display(Name = "Tháng")]
        public int Thang { get; set; }

        [Display(Name = "Năm")]
        public int Nam { get; set; }

        public string Ho { get; set; }
        public string Ten { get; set; }

        [Display(Name = "Họ và tên")]
        public string HoTen => Ho + " " + Ten;

        [Display(Name = "Có mặt")]
        public int CoMat { get; set; }

        [Display(Name = "Đi trễ")]
        public int Tre { get; set; }

        [Display(Name = "Vắng không phép")]
        public int KhongPhep { get; set; }

        [Display(Name = "Vắng có phép")]
        public int CoPhep { get; set; }

        [Display(Name = "Nghỉ không lương")]
        public int TheoQuyDinh { get; set; }
    }
}
