using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Live.Models.NhanSu.Request
{
    public class CapPhepNam
    {
        public int NhanVienId { get; set; }
        [Required]
        public int Nam { get; set; }
        [Required]
        [Range(1,12)]
        public int SoPhep { get; set; }
    }
}
