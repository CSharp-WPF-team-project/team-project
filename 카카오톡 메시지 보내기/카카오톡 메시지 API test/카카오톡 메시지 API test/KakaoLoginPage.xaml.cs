using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using 카카오톡_메시지_API_test.Scripts;

namespace 카카오톡_메시지_API_test
{
    /// <summary>
    /// KakaoLoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    
    public partial class KakaoLoginPage : Window
    {
        KakaoManager kakaoManager;
        public KakaoLoginPage()
        {
            InitializeComponent();

            kakaoManager = new KakaoManager();

            WebBrowser.DocumentCompleted += WebBrowser1_DocumentCompleted;

            webBrowser1.Navigate(KakaoApiEndPoint.KakaoLogInUrl);
        }
    }
}
