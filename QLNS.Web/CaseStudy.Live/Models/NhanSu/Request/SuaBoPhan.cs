using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Request
{
    public class SuaBoPhan
    {
        public int Id { get; set; }
        [Display(Name = "Bộ Phận")]
        [StringLength(100)]
        public string Ten { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool DangHoatDong { get; set; }

    }
}
