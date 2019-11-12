using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Domain.Request.NhanSu
{
   public class TimKiemNhanVien
    {
        public int Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string GioiTinhStr => GioiTinh ? "Nam" : "Nữ";
        public string HoTen => Ho + Ten;
    }
}
