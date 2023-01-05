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
    public partial class PageDonHangCuaBan : ContentPage
    {
        public PageDonHangCuaBan()
        {
            InitializeComponent();
            LayDonHangtheoIDNguoiDung(NguoiDung.nguoidung.MaNguoiDung);
            
        }
        async void LayDonHangtheoIDNguoiDung(int manguoidung)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://172.30.163.1/webapinew/api/NguoiDung/LaySoDHtheoIDNguoiDung?manguoidung=" + manguoidung.ToString());
            var dsdh = JsonConvert.DeserializeObject<List<DonHang>>(kq);
            lstdonhangcuaban.ItemsSource = dsdh;
        }

        private void lstdonhangcuaban_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DonHang dh = (DonHang)e.SelectedItem;
            Navigation.PushAsync(new PageCTDonHang(dh));
        }
    }
}