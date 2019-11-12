using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Live.Models.NhanVien.Request
{
    public class DonXinPhepCreate
    {
        public int Id { get; set; }
        public int NhanVienId { get; set; }
        public int QuanLyId { get; set; }

        [Display(Name = "Tình Trạng: ")]
        public int TinhTrang { get; set; }

        [Display(Name = "Nghỉ từ ngày: "), DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }

        [Display(Name = "Đến ngày: "), DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }

        [Display(Name = "Số Ngày Phép Còn Lại: ")]
        public int SoPhepConLai { get; set; }

        [Display(Name = "Số Ngày Phép Đã Nghỉ: ")]
        public int SoNgayDaNghi { get; set; }

        [Display(Name = "Ngày Gửi: "), DataType(DataType.Date)]
        public DateTime NgayGui { get; set; }

        [Display(Name = "Ngày Phản Hồi: "),DataType(DataType.Date)]
        public DateTime NgayPhanHoi { get; set; }

        [Display(Name = "Ghi Chú")]
        public string GhiChu { get; set; }
        public string TraLoi { get; set; }

        [Display(Name = "Họ tên:")]
        public string HoTen { get; set; }

        [Display(Name = "Bộ Phận")]
        public string BoPhan { get; set; }

        [Display(Name = "Số Ngày Trễ")]
        public int Tre { get; set; }
        [Display(Name = "Số Ngày Không Phép")]
        public int KhongPhep { get; set; }
        public string Email { get; set; }
    }
}
