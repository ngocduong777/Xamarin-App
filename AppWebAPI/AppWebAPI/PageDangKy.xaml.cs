using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWebAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDangKy : ContentPage
    {
        public PageDangKy()
        {
            InitializeComponent();
           /* if (NguoiDung.nguoidung.MaNguoiDung > 0)
            {
                txttennd.Text = NguoiDung.nguoidung.TenNguoiDung;
                txttendn.Text = NguoiDung.nguoidung.TenDangNhap;
                txtEmail.Text = NguoiDung.nguoidung.Email;
            }*/
        }

        private async void cmddangky_Clicked(object sender, EventArgs e)
        {
            if (txtmatkhau.Text != txtmatkhaunl.Text)
            {
                await DisplayAlert("Thông báo", "Mật khẩu nhập lại không đúng", "OK");
                return;
            }
            NguoiDung nd = new NguoiDung { MaNguoiDung=0,TenNguoiDung = txttennd.Text, TenDangNhap = txttendn.Text, MatKhau = txtmatkhau.Text, Email = txtEmail.Text };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(nd);
            StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq = await http.PostAsync
                ("http://172.30.163.1/webapinew/api/NguoiDung/ThemNguoiDung", httpcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            nd = JsonConvert.DeserializeObject<NguoiDung>(kqtv);
            if (nd.MaNguoiDung > 0)
                await DisplayAlert("Thông báo", "Tạo tài khoản thành công", "OK");
            else
                await DisplayAlert("Thông báo", "Tài khoản đã tồn tại" , "OK");
        }
    }
}