using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWebAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUser : ContentPage
    {
        public PageUser()
        {
            InitializeComponent();

        }

        private void thongtincanhan_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageUserDetail());
        }

        private void donhangcuaban_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageDonHangCuaBan());
        }

        private async void logout_Clicked(object sender, EventArgs e)
        {
            bool agree_logout= await DisplayAlert("Thông báo", "Bạn có muốn đăng xuất không?", "Đồng ý", "Hủy");
            if (agree_logout)
            {
                NguoiDung.nguoidung.MaNguoiDung = 0;

                NguoiDung.nguoidung.TenNguoiDung = null;
                NguoiDung.nguoidung = null;

                await Shell.Current.GoToAsync("//login");
                Application.Current.MainPage = new AppShell();
            }

        }
    }
}