﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapinew.Models
{
    public class Hoa
    {
        public int MaHoa { get; set; }
        public int MaLoai { get; set; }
        public string TenHoa { get; set; }
        public string Hinh { get; set; }
        public int GiaBan { get; set; }
        public string MoTa { get; set; }
        public int Soluong { get; set; }
    }
}