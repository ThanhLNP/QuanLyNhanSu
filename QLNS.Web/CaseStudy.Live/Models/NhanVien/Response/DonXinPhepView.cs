using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Live.Models.NhanVien.Response
{
    public class DonXinPhepView
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public int QuanLyId { get; set; }

        [Display(Name ="Tình Trạng")]
        public string TinhTrang { get; set; }

        [Display(Name = "Ngày Bắt Đầu"), DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }

        [Display(Name = "Ngày Kết Thúc"), DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }

        [Display(Name = "Số Phép Còn Lại")]
        public int SoPhepConLai { get; set; }

        [Display(Name = "Số Phép Số Ngày Đã Nghỉ")]
        public int SoNgayDaNghi { get; set; }

        [Display(Name = "Ngày Gửi"), DataType(DataType.Date)]
        public DateTime NgayGui { get; set; }

        [Display(Name = "Ngày Phản Hồi"), DataType(DataType.Date)]
        public DateTime NgayPhanHoi { get; set; }

        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }

        [Display(Name = "Trả Lời")]
        public string TraLoi { get; set; }
    }
}
