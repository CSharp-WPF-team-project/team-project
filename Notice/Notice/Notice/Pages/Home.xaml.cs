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
//Selenium Library
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Notice.Pages
{
    /// <summary>
    /// Home.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Home : Page
    {
        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;

        public Home()
        {
            InitializeComponent();

            _driverService = ChromeDriverService.CreateDefaultService();
            _driverService.HideCommandPromptWindow = true;

            _options = new ChromeOptions();
            _options.AddArgument("headless");
            _options.AddArgument("disable-gpu");


        }

        private void searcingButton_Click(object sender, EventArgs e)
        {
            _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl("https://cse.jbnu.ac.kr/cse/3586/subview.do");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            
           
        }
    }
}
