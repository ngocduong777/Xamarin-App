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
    public partial class PageFinalBill : ContentPage
    {
        
        public int TinhTongBill()
        {
            int tongcong = 0;
            foreach (Hoa h in NguoiDung.giohang.DsHoa)
            {

                tongcong = tongcong + (h.GiaBan * h.Soluong);

            }
            return tongcong;
        }
         public int TinhTongSoLuong()
        {
            int tongcong = 0;
            foreach (Hoa h in NguoiDung.giohang.DsHoa)
            {

                tongcong = tongcong + h.Soluong;

            }
            return tongcong;
        }
        public PageFinalBill()
        {
            InitializeComponent();          
            lstsanpham.ItemsSource = NguoiDung.giohang.DsHoa;
            
            tongcongbill.Text = "Tổng cộng: " + TinhTongBill().ToString();
            tongsoluong.Text = "Số lượng: " + TinhTongSoLuong().ToString();
            if (TinhTongBill() == 0)
            {
                Muahang.IsEnabled = false;
            }
        }

        private async void Muahang_Clicked(object sender, EventArgs e)
        {
            if (NguoiDung.nguoidung.MaNguoiDung == 0)
            {
                await DisplayAlert("Thông Báo", "Bạn phải đăng nhập trước khi mua hàng", "Đồng Ý");
                return;
            }

            NguoiDung.giohang.Ma_Nguoi_Dung = NguoiDung.nguoidung.MaNguoiDung;
            NguoiDung.giohang.Dia_Chi_Giao = txtdiachigiaohang.Text;
            NguoiDung.giohang.Loi_Nhan = txtdiachiloinhan.Text;

            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(NguoiDung.giohang);
            StringContent httcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;


            kq = await http.PostAsync("http://172.30.163.1/webapinew/api/NguoiDung/ThemGioHang", httcontent);

            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
            {
                await DisplayAlert("Thông báo", "Mua hàng thành công", "OK");

                NguoiDung.giohang.DsHoa = new List<Hoa>();
                /*lstgiohang.ItemsSource = NguoiDung.giohang.DsHoa;*/
            }
            else
            {
                await DisplayAlert("Thông báo", "Không thành công", "OK");
                await Navigation.PushAsync(new PageLoaiHoa());
            }
        }
    }
}