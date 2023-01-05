using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using webapinew.Models;

namespace webapinew.Controllers
{
    public class Database
    {

    public static DataTable Read_Table(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString; 
            DataTable result = new DataTable("table1"); 
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open(); SqlCommand cmd = conn.CreateCommand(); 
                cmd.Connection = conn; 
                cmd.CommandText = StoredProcedureName; 
                cmd.CommandType = CommandType.StoredProcedure; 
                if (dic_param != null) 
                { 
                    foreach (KeyValuePair<string, object> data in dic_param) 
                    { 
                        if (data.Value == null) 
                        { 
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value); 
                        } 
                        else 
                        { 
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value); 
                        } 
                    } 
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(); 
                    da.SelectCommand = cmd; 
                    da.Fill(result);

                }
                catch (Exception ex)
                {

                }
            }
            return result;
        } 

    public static DataTable LayDSLoaiHoa()
        {
            DataTable tb = Read_Table("LayDsloaihoa");
            return tb;
        }

    public static DataTable LayDSHoaTheoLoai(int MaLoai)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("maloai", MaLoai);
            DataTable tb = Read_Table("LayhoatheoLoai",param);
            return tb;
        }
        public static DataTable LaySoDHtheoIDNguoiDung(int MaNguoiDung)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("manguoidung", MaNguoiDung);
            DataTable tb = Read_Table("LaySoDHtheoIDNguoiDung", param);
            return tb;
        }
        public static DataTable LayMaHoaTheoSoDH(int Ma_DH)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("So_DH", Ma_DH);
            DataTable tb = Read_Table("LayMaHoaTheoSoDH", param);
            return tb;
        }
        public static DataTable LayTongBillDiaChiLoiNhanTheoSoDH (int So_DH)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("So_DH", So_DH);
            DataTable tb = Read_Table("LayTongBillDiaChiLoiNhanTheoSoDH", param);
            return tb;
        }


        //Xay dung ham cho cac store cap nhat du lieu
        // goi cac store cap nhat
        public static object Exec_Command(string StoredProcedureName, Dictionary<string, object> dic_param = null)
        {
            string SQLconnectionString = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
            object result = null;
            using (SqlConnection conn = new SqlConnection(SQLconnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();



                // Start a local transaction.



                cmd.Connection = conn;
                cmd.CommandText = StoredProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;



                if (dic_param != null)
                {
                    foreach (KeyValuePair<string, object> data in dic_param)
                    {
                        if (data.Value == null)
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                        }
                    }
                }
                cmd.Parameters.Add("@CurrentID", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters["@CurrentID"].Value;
                    // Attempt to commit the transaction.



                }
                catch (Exception ex)
                {



                    result = null;
                }



            }
            return result;
        }

  

        public static int CapNhatLoaiHoa(LoaiHoa lh)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("maloai", lh.Maloai);
            param.Add("Tenloai", lh.Tenloai);
            int kq = int.Parse(Exec_Command("Cap_Nhat_Loai_hoa", param).ToString());
            return kq;
        }

        public static int CapNhatNguoiDung(NguoiDung nd)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("manguoidung", nd.MaNguoiDung);
            param.Add("tennguoidung", nd.TenNguoiDung);
            int kq = int.Parse(Exec_Command("Cap_Nhat_Nguoi_Dung", param).ToString());
            return kq;


        }
        public static int XoaLoaiHoa(LoaiHoa lh)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("maloai", lh.Maloai);
            int kq = int.Parse(Exec_Command("Xoa_Loai_Hoa", param).ToString());
            return kq;
        }
        public static int Them_Loai_Hoa(LoaiHoa lh)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("Tenloai", lh.Tenloai);
            int kq = int.Parse(Exec_Command("Them_Loai_Hoa", param).ToString());
            return kq;
        }

        public static NguoiDung ThemNguoiDung(NguoiDung nd)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("TenNguoiDung", nd.TenNguoiDung);
            param.Add("TenDangNhap", nd.TenDangNhap);
            param.Add("MatKhau", nd.MatKhau);
            param.Add("Email", nd.Email);
            int kq = int.Parse(Exec_Command("ThemNguoiDung", param).ToString());
             if (kq > -1)
                 nd.MaNguoiDung = kq;
            return nd;

            
        }

        public static NguoiDung DangNhap(string TenDangNhap, string MatKhau)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("tendangnhap", TenDangNhap);
            param.Add("matkhau", MatKhau);
            DataTable tb = Read_Table("DangNhap", param);
            NguoiDung kq = new NguoiDung();
            if (tb.Rows.Count > 0)
            {
                kq.MaNguoiDung = int.Parse(tb.Rows[0]["MaNguoiDung"].ToString());
                kq.TenNguoiDung = tb.Rows[0]["TenNguoiDung"].ToString();
                kq.TenDangNhap = tb.Rows[0]["TenDangNhap"].ToString();
                kq.Email = tb.Rows[0]["Email"].ToString();
                kq.MatKhau = tb.Rows[0]["MatKhau"].ToString();
            }
            else
                kq.MaNguoiDung = 0;
            return kq;


        }


        public static int ThemGioHang(GioHang gh)
        {
            //khai bao datatable chua ds hang
            DataTable tb = new DataTable();
            tb.Columns.Add("ma_hoa", typeof(int));
            tb.Columns.Add("so_luong", typeof(int));
            tb.Columns.Add("don_gia", typeof(float));
            tb.Columns.Add("thanh_tien", typeof(float));
            foreach (Hoa h in gh.DsHoa)
            {
                DataRow r = tb.NewRow();
                r["ma_hoa"] = h.MaHoa;
                r["so_luong"] = h.Soluong;
                r["don_gia"] = h.GiaBan;
                r["thanh_tien"] = h.Soluong * h.GiaBan;
                tb.Rows.Add(r);
            }
            tb.AcceptChanges();
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("Ma_Nguoi_dung", gh.Ma_nguoi_dung);
            param.Add("Dia_Chi_Giao", gh.Dia_Chi_Giao);
            param.Add("Loi_Nhan", gh.Loi_Nhan);
            param.Add("t", tb);
            int kq = int.Parse(Exec_Command("Them_Don_Hang", param).ToString());

            return kq;
        }


    }
}