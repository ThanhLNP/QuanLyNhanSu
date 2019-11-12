using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseStudy.Live.Models.NhanSu.Request
{
    public class ThemBoPhan
    {
        [Display(Name = "Tên Bộ Phận")]
        [Required]
        [StringLength(50)]
        public string Ten { get; set; }
    }
}
