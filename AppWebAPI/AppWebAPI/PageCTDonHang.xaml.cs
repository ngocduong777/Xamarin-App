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
    public partial class PageCTDonHang : ContentPage
    {

        public  PageCTDonHang(DonHang dh)
        {
            InitializeComponent();
            LayCTDH(dh);
            Title = "Mã đơn hàng: " + dh.SoDH;
            LayTongBill(dh);
           
           
        }
        async void LayTongBill(DonHang dh)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://172.30.163.1/webapinew/api/NguoiDung/LayTongBillDiaChiLoiNhanTheoSoDH?So_DH=" + dh.SoDH.ToString());
            var tongBills = JsonConvert.DeserializeObject<List<TongBillDiaChiLoiNhanTheoSoDH>>(kq);
            lsttongbill.ItemsSource = tongBills;
        }
        async void LayCTDH(DonHang dh)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://172.30.163.1/webapinew/api/NguoiDung/LayMaHoaTheoSoDH?Ma_DH=" + dh.SoDH.ToString());
            var CTDH = JsonConvert.DeserializeObject<List<CTDonHang>>(kq);
            lstCTDH.ItemsSource = CTDH;
            
        }

 
    }
}