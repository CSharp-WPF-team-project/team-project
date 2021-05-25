using System.Windows;
using System.Windows.Controls;

namespace Notice.View
{
    /// <summary>
    /// Binding.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Binding : Page
    {
        public Binding()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(sender == oasis)
            {
                System.Diagnostics.Process.Start("https://all.jbnu.ac.kr/jbnu/oasis/index.html");
            }
            if(sender==newLMS)
            {
                System.Diagnostics.Process.Start("https://ieilms.jbnu.ac.kr/");
            }
            if(sender==oldLMS)
            {
                System.Diagnostics.Process.Start("https://ieilmsold.jbnu.ac.kr/login.php?errorcode=3");
            }
        }
    }
}
