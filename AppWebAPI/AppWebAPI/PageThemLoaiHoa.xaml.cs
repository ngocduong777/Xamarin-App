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
    public partial class PageThemLoaiHoa : ContentPage
    {
        public PageThemLoaiHoa()
        {
            InitializeComponent();
            LayDSLoaiHoa();
        }
        async void LayDSLoaiHoa()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://172.30.163.1/webapinew/api/LoaiHoa/LayDSLoaiHoa");
            var dslh = JsonConvert.DeserializeObject<List<LoaiHoa>>(kq);
            lstloaihoa.ItemsSource = dslh;
        }


        private async void cmdThem_Clicked(object sender, EventArgs e)
        {
            LoaiHoa lh = new LoaiHoa { MaLoai = 0, TenLoai = txttenloai.Text };
            HttpClient http = new HttpClient();
            string jsonlh = JsonConvert.SerializeObject(lh);
            StringContent httpcontent = new StringContent(jsonlh, Encoding.UTF8, "application/json");
            HttpResponseMessage kq = await http.PostAsync("http://172.30.163.1/webapinew/api/LoaiHoa/ThemLoaiHoa", httpcontent);
            var kqtv = await kq.Content.ReadAsStringAsync();
            if (int.Parse(kqtv) == -1)
                await DisplayAlert("Thong Bao", "Ten Hoa Da Co", "Ok");
            else if (int.Parse(kqtv) == 0)
                await DisplayAlert("THong Bao", "Loi He Thong", "OK");
            else
            {
                await DisplayAlert("Thong bao", "Them Hoa Thanh cong","OK");
                LayDSLoaiHoa();
            }

        }

        private void lstloaihoa_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}