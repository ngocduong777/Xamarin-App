using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWebAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHoa : ContentPage
    {
         async void LayDSHoaTheoLoai(LoaiHoa lh)
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://172.30.163.1/webapinew/api/Hoa/LayDSHoaTheoLoai?maloai=" + lh.MaLoai.ToString());
            var dsh = JsonConvert.DeserializeObject<List<Hoa>>(kq);
            lsthoa.ItemsSource = dsh;
            Title = lh.TenLoai;
            if (lh.TenLoai == "Gia vị & Sốt")
            {
                banner_cate.Source = "giavisot_banner.png";
            }
            if (lh.TenLoai == "Thực phẩm ăn liền")
            {
                banner_cate.Source = "anlien_banner.png";
            }
            if (lh.TenLoai == "Bánh kẹo")
            {
                banner_cate.Source = "banhkeo_banner.png";
            }
            if (lh.TenLoai == "Đồ uống")
            {
                banner_cate.Source = "douong_banner.png";
            }
            if (lh.TenLoai == "Rong biển")
            {
                banner_cate.Source = "rongbien_banner.png";
            }

        }
        public PageHoa(LoaiHoa lh)
        {
            InitializeComponent();
            LayDSHoaTheoLoai(lh);
        }

        private void cmdMuaHang_Clicked(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Hoa hc = (Hoa)bt.BindingContext;
            bool choosen = false;
            foreach(Hoa h in NguoiDung.giohang.DsHoa)
            {
                if (hc.MaHoa == h.MaHoa)
                {
                    hc.Soluong++;
                    choosen = true;
                    break;
                }
              
            }
            if (choosen == false)
            {
                hc.Soluong = 1;
                NguoiDung.giohang.DsHoa.Add(hc);
            }
            DisplayAlert("Thông báo", "Đã thêm vào giỏ hàng", "OK");
        }
    }
}