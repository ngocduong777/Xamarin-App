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
    public partial class PageLoaiHoa : ContentPage
    {
        public PageLoaiHoa()
        {
            InitializeComponent();
            LayDSLoaiHoa();
           /* if (NguoiDung.nguoidung.MaNguoiDung > 0)
            { Title = "Xin chào " + NguoiDung.nguoidung.TenNguoiDung; }*/
        }
        async void LayDSLoaiHoa()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://172.30.163.1/webapinew/api/LoaiHoa/LayDSLoaiHoa");
            var dslh = JsonConvert.DeserializeObject<List<LoaiHoa>>(kq);
            lstdslh.ItemsSource = dslh;
        }
        private void lstdslh_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LoaiHoa lh = (LoaiHoa)e.SelectedItem;
            Navigation.PushAsync(new PageHoa(lh));
        }

        private async void logout_Clicked(object sender, EventArgs e)
        {
            NguoiDung.nguoidung.MaNguoiDung = 0;
            
            NguoiDung.nguoidung.TenNguoiDung = null;
            NguoiDung.nguoidung = null;
            
            await Shell.Current.GoToAsync("//login");
            Application.Current.MainPage = new AppShell();
        }
    }
}