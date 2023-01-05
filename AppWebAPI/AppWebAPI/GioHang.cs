using System;
using System.Collections.Generic;
using System.Text;

namespace AppWebAPI
{
    public class GioHang
    {
    /*    public int SoDH { get; set; }*/
        public int Ma_Nguoi_Dung { get; set; }
        public string Dia_Chi_Giao { get; set; }
        public string Loi_Nhan { get; set; }
        public List<Hoa> DsHoa { get; set; }

    }
}
