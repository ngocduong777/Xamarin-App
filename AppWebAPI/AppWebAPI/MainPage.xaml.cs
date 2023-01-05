using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
namespace AppWebAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void chaoAPI()
        {
            HttpClient http = new HttpClient();
            var kq = await http.GetStringAsync("http://192.168.1.139/webapinew/api/XuLy/Chao");
            lblchao.Text = kq.ToString();
        }
        private void cmdchaoAPI_Clicked(object sender, EventArgs e)
        {
            chaoAPI();
        }
    }
}
