using System;
using System.Collections.Generic;
using System.Text;

namespace AppWebAPI
{
    public class NguoiDung
    {
        public int MaNguoiDung {get;set;}
        public string TenNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public static NguoiDung nguoidung;
        public static GioHang giohang;

    }
}
