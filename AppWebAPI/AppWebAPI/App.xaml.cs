using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWebAPI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            NguoiDung.nguoidung = new NguoiDung();
            NguoiDung.giohang = new GioHang();
            NguoiDung.giohang.DsHoa = new System.Collections.Generic.List<Hoa>();
            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
