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
using System.Windows.Navigation;
using System.Windows.Shapes;
using 카카오톡_메시지_API_test.Scripts;

namespace 카카오톡_메시지_API_test
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private KakaoLoginPage kakaoLoginPage;
        private KakaoManager kakaoManager;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += KakaoMain_Load; // 로드 이벤트 추가
            kakaoManager = new KakaoManager();
            Console.WriteLine(KakaoApiEndPoint.KakaoLogInUrl);

        }

        private void KakaoMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine("폼 로드");

            WebBrowserVersionSetting();
        }

        private void WebBrowserVersionSetting()
        {
            throw new NotImplementedException();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("로그인 버튼");
            kakaoLoginPage = new KakaoLogInPage();
            kakaoLoginPage.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("로그아웃 버튼");
            kakaoManager.KakaoTalkLogOut();
        }

        private void templateMessage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void customMessage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
