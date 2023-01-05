using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapinew.Models
{
    public class NguoiDung
    {
        public int MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    }
}