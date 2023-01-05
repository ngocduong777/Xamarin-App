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
    public partial class PageUserDetail : ContentPage
    {
        NguoiDung nd;
        public PageUserDetail()
        {
            InitializeComponent();
            if (NguoiDung.nguoidung.MaNguoiDung > 0)
            {
                entrytennguoidung.Text = NguoiDung.nguoidung.TenNguoiDung;
                entrytendangnhap.Text = NguoiDung.nguoidung.TenDangNhap;
                entryemail.Text = NguoiDung.nguoidung.Email;
            }
            nd = new NguoiDung();



        }

        private async void update_btn_Clicked(object sender, EventArgs e)
        {
            if (entrytennguoidung.Text == "")
            {
                await DisplayAlert("Thông báo", "Tên người dùng không được bỏ trống!", "OK");
            }
            nd = NguoiDung.nguoidung;
            nd.TenNguoiDung = entrytennguoidung.Text;
            nd.MaNguoiDung = NguoiDung.nguoidung.MaNguoiDung;
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(nd);
            StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            kq = await http.PostAsync("http://172.30.163.1/webapinew/api/NguoiDung/CapNhatNguoiDung", httpcontent);

            var kqtv = await kq.Content.ReadAsStringAsync();

            if (int.Parse(kqtv.ToString()) > 0)
            {
                await DisplayAlert("Thông báp", "Cập nhật thành công", "OK");
                
            }
            else
            {
                await DisplayAlert("Thông báo", "Cập nhật thất bại", "OK");
            }

        }
    }
}