using Newtonsoft.Json.Linq;
using Notice.Model;
using Notice.ViewModel.KakaoApi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notice.View
{
    /// <summary>
    /// KakaoLoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class KakaoLoginPage : Window
    {
        KakaoManager kakaoManager;
        
        public KakaoLoginPage()
        {
            InitializeComponent();

            kakaoManager = new KakaoManager();

            WebBrowser1.LoadCompleted += WebBrowser1_DocumentCompleted;

            WebBrowser1.Navigate(KakaoApiEndPoint.KakaoLogInUrl);
        }

        private void WebBrowser1_DocumentCompleted(object sender, NavigationEventArgs e)
        {
            string code = kakaoManager.GetUserToKen(WebBrowser1);
            if (code != "")
            {
                KakaoData.userToken = code;
                KakaoData.accessToken = kakaoManager.GetAccessToKen();
                this.Close();
            }
        }
    }
}
