using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapinew.Models
{
    public class GioHang
    { 
        public int Ma_nguoi_dung { get; set; }
        public string Dia_Chi_Giao { get; set; }
        public string Loi_Nhan { get; set; }
        public List<Hoa> DsHoa { get; set; }
    }
}