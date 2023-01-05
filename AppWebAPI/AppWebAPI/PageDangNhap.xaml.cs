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
    public partial class PageDangNhap : ContentPage
    {
        public PageDangNhap()
        {
            InitializeComponent();
        }

        private async void cmddangnhap_Clicked(object sender, EventArgs e)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync
                ("http://172.30.163.1/webapinew/api/NguoiDung/DangNhap?TenDangNhap=" +
                txttendn.Text + "&&MatKhau=" + txtmatkhau.Text);
            var nd = JsonConvert.DeserializeObject<NguoiDung>(kq);
            if (nd.TenNguoiDung != "" && nd.TenNguoiDung != null)
            {

                NguoiDung.nguoidung = nd;
                await Shell.Current.GoToAsync("//main");

            }
            else
                await DisplayAlert("Thông báo", "Vui lòng điền chính xác thông tin", "OK");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
            await Shell.Current.GoToAsync("//login/registration");
            
        }
    }
}