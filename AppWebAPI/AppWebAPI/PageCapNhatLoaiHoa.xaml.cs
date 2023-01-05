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
    public partial class PageCapNhatLoaiHoa : ContentPage
    {
        LoaiHoa lh;
        public PageCapNhatLoaiHoa()
        {
            InitializeComponent();
            LayDSLoaiHoa();
            lh = new LoaiHoa();
        }

        public async void LayDSLoaiHoa()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://172.30.163.1/webapinew/api/LoaiHoa/LayDSLoaiHoa");
            var dslh = JsonConvert.DeserializeObject<List<LoaiHoa>>(kq);
            lstloaihoa.ItemsSource = dslh;
        }
        private void lstloaihoa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            lh = (LoaiHoa)lstloaihoa.SelectedItem;
            txttenloai.Text = lh.TenLoai;

        }

        private void cmdThem_Clicked(object sender, EventArgs e)
        {
            txttenloai.Text = "";
            lh = new LoaiHoa { MaLoai = 0 };
            txttenloai.Focus();
        }

        private async void cmdGhi_Clicked(object sender, EventArgs e)
        {
            if (txttenloai.Text == "")
            {
                await DisplayAlert("Thong bao", "Phai nhap ten loai hoa", "OK");
            }

            lh.TenLoai = txttenloai.Text;
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(lh);
            StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq;
            if (lh.MaLoai > 0)
            {
                kq = await http.PostAsync("http://172.30.163.1/webapinew/api/LoaiHoa/CapNhatLoaiHoa", httpcontent);
            }
            else
            {
                kq = await http.PostAsync("http://172.30.163.1/webapinew/api/LoaiHoa/ThemLoaiHoa", httpcontent);

            }
            var kqtv = await kq.Content.ReadAsStringAsync();

            if (int.Parse(kqtv.ToString()) > 0)
            {
                await DisplayAlert("Thong bao", "Cap nhat du lieu thanh cong", "OK");
                LayDSLoaiHoa();
            }
            else
            {
                await DisplayAlert("Thong bao", "Cap nhat that bai", "OK");
            }





        }

        private void cmdKhong_Clicked(object sender, EventArgs e)
        {

        }

        private async void cmdXoa_Clicked(object sender, EventArgs e)
        {
            if (lh.MaLoai == 0)
                return;
            var tb = await DisplayAlert("Thong bao", "Ban co muon xoa " + lh.TenLoai + " khong", "OK", "Khong");
            if(tb)
            {
                HttpClient http = new HttpClient();
                string jsonlh = JsonConvert.SerializeObject(lh);
                StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
                HttpResponseMessage kq;
                kq = await http.PostAsync("http://172.30.163.1/webapinew/api/LoaiHoa/XoaLoaiHoa", httpcontent);
                var kqtv = await kq.Content.ReadAsStringAsync();
                if (int.Parse(kqtv.ToString()) > 0)
                {
                    await DisplayAlert("Thong bao", "Xoa du lieu thanh cong", "OK");
                    LayDSLoaiHoa();
                }
                else
                {
                    await DisplayAlert("Thong bao", "Xoa that bai", "OK");
                }

            }

        }
    }
}