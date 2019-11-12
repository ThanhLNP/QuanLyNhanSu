using System;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.QuanLy.Response
{
    public class DonXinPhep
    {
        public int DonXinPhepId { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }

        [Display(Name = "Họ và tên")]
        public string HoTen => Ho + " " + Ten;

        [Display(Name = "Tình trạng")]
        public int TinhTrang { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

        [Display(Name = "Số phép còn lại")]
        public int SoPhepConLai { get; set; }

        [Display(Name = "Số ngày đã nghỉ")]
        public int SoNgayDaNghi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày gửi")]
        public DateTime NgayGui { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày phản hồi")]
        public DateTime? NgayPhanHoi { get; set; }

        [Display(Name = "Ghi chú của người gửi")]
        public string GhiChu { get; set; }

        [Display(Name = "Ghi chú của người trả lời")]
        public string TraLoi { get; set; }
        public string Email { get; set; }

        public int QuanLyId { get; set; }
    }
}
