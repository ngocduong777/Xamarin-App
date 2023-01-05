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
    public partial class Page_GioHang : ContentPage
    {

        public Page_GioHang()
        {
            InitializeComponent();
            lstgiohang.ItemsSource = NguoiDung.giohang.DsHoa;
            


        }

        /*private void cmdCapnhat_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Hoa hc = (Hoa)bt.BindingContext;
            foreach (Hoa h in NguoiDung.giohang.DsHoa)
            {
                if (hc.MaHoa == h.MaHoa)
                {
                    h.Soluong = hc.Soluong;
                    break;
                }
            }

            

        }*/

        private async void cmdxoa_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Hoa hc = (Hoa)bt.BindingContext;

            var tb = await DisplayAlert("Thông Báo", "Bạn có muốn xóa "
                + hc.TenHoa + " trong giỏ hàng không?", "Đồng Ý", "Không");
            if (tb)
            {
                foreach (Hoa h in NguoiDung.giohang.DsHoa)
                {
                    if (hc.MaHoa == h.MaHoa)
                    {
                        NguoiDung.giohang.DsHoa.Remove(h);
                        break;
                    }
                }
            }
            lstgiohang.ItemsSource = null;
            lstgiohang.ItemsSource = NguoiDung.giohang.DsHoa;

           


        }

        private  void cmdMuahang_Clicked(object sender, EventArgs e)
        {
            /*if (NguoiDung.nguoidung.MaNguoiDung == 0)
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


            kq = await http.PostAsync("http://192.168.1.139/webapinew/api/NguoiDung/ThemGioHang", httcontent);

            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv.ToString()) > 0)
            {
                await DisplayAlert("Thông báo", "them gio hang thanh cong", "ok");

                NguoiDung.giohang.DsHoa = new List<Hoa>();
               lstgiohang.ItemsSource = NguoiDung.giohang.DsHoa;
            }
            else
            { await DisplayAlert("Thông báo", "Them dữ liệu Lỗi", "ok");
                await Navigation.PushAsync(new PageLoaiHoa());
            }*/

            Navigation.PushAsync(new PageFinalBill());

        }


       
    }
}