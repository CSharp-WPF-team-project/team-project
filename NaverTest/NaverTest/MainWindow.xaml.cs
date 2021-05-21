using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NaverTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        }

        private void NaverLogin_Click(object sender, RoutedEventArgs e)
        {
            String ClientID = "fB9PdAptMEE7HUFSP6Ww";
            String RedirectURL = "http://localhost:8089/naver/callback.php";

            String State = (new Random()).Next().ToString();

            NameValueCollection listAuthURL_QueryString = HttpUtility.ParseQueryString(string.Empty);
            listAuthURL_QueryString["response_type"] = "code";
            listAuthURL_QueryString["client_id"] = ClientID;
            listAuthURL_QueryString["redirect_uri"] = RedirectURL;
            listAuthURL_QueryString["state"] = State;

            string AuthURL = "https://nid.naver.com/oauth2.0/authorize?"+ listAuthURL_QueryString.ToString();

            NaverWebBrowser.Navigate(new Uri(AuthURL));
        }
    }
}
