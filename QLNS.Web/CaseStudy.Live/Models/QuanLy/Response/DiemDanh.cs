using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.QuanLy.Response
{
    public class DiemDanh
    {
        [Required]
        public int NhanVienId { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }

        [Display(Name = "Họ và tên")]
        public string HoTen => Ho + " " + Ten;

        [Display(Name = "Trạng thái")]
        [Range(1, 5)]
        [Required]
        public int TrangThai { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày")]
        [Range(typeof(DateTime), "1/1/2019", "1/1/2029",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Ngay { get; set; }

        public int QuanLyId { get; set; }
    }
}
