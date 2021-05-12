using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace crawling
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{

		protected ChromeDriverService _driverService = null;
		protected ChromeOptions _options = null;
		protected ChromeDriver _driver = null;

		public MainWindow()
		{
			InitializeComponent();

			button1.Click += button1_Initialized;
			//button2.Click += button2_Initialized;

			_driverService = ChromeDriverService.CreateDefaultService();
			_driverService.HideCommandPromptWindow = true;

			_options = new ChromeOptions();
			_options.AddArgument("headless");
			_options.AddArgument("disable-gpu");
		}

		private void button1_Initialized(object sender, EventArgs e)
		{

			string id = loginTextBox.Text;
			string pw = passwordTextBox.Text;


			_driver = new ChromeDriver(_driverService, _options);

			_driver.Navigate().GoToUrl("https://ieilms.jbnu.ac.kr/"); // 웹 사이트에 접속합니다.

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);



			var element = _driver.FindElementByXPath("//*[@id='id']");
			element.SendKeys(id);

			element = _driver.FindElementByXPath("//*[@id='passwd']");
			element.SendKeys(pw);

			element = _driver.FindElementByXPath("//*[@id='loginform']/table/tbody/tr[1]/td[2]/input");
			element.Click();

			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[1]/td[2]");
			element.Click();

			element = _driver.FindElementByXPath("//*[@id='nav']/li[3]/a");
			element.Click();

			// 학점선택 체크박스
			IEnumerable<CheckBox> ChkBoxes = from checkbox in this.StackPanelGroup1.Children.OfType<CheckBox>()
												 // where checkbox.IsChecked.Value 체크된 Checkbox 만 선택할때
											 select checkbox;
			// 체크된 content 값 가져오기
			foreach (CheckBox Chkbox in ChkBoxes)
			{
				if (Chkbox.IsChecked == true)
				{
					if (Chkbox.Content.ToString() == "21.5학점")
					{
						textUpLoad();
						for (int i = 3; i < 10; i++)
						{
                            element = _driver.FindElementByXPath("//*[@id='center']/div/div[2]/div/div[3]/a/span");
						    element.Click();
							string BASE_Path = "//*[@id='treeboxtab']/div/table/tbody/tr[{0}]/td[2]/table/tbody/tr/td[4]/span";
							string url = string.Format(BASE_Path, i);
				            string BASE_value = url;
							element = _driver.FindElementByXPath(BASE_value);
							element.Click();
							textUpLoad();
						}
					}
					if (Chkbox.Content.ToString() == "18.5학점")
					{
						textUpLoad();
						for (int i = 3; i < 9; i++)
						{
							element = _driver.FindElementByXPath("//*[@id='center']/div/div[2]/div/div[3]/a/span");
							element.Click();
							string BASE_Path = "//*[@id='treeboxtab']/div/table/tbody/tr[{0}]/td[2]/table/tbody/tr/td[4]/span";
							string url = string.Format(BASE_Path, i);
							string BASE_value = url;
							element = _driver.FindElementByXPath(BASE_value);
							element.Click();
							textUpLoad();
						}
					}
					if (Chkbox.Content.ToString() == "15.5학점")
					{
						textUpLoad();
						for (int i = 3; i < 8; i++)
						{
							element = _driver.FindElementByXPath("//*[@id='center']/div/div[2]/div/div[3]/a/span");
							element.Click();
							string BASE_Path = "//*[@id='treeboxtab']/div/table/tbody/tr[{0}]/td[2]/table/tbody/tr/td[4]/span";
							string url = string.Format(BASE_Path, i);
							string BASE_value = url;
							element = _driver.FindElementByXPath(BASE_value);
							element.Click();
							textUpLoad();
						}
					}
				}
			}

			// 전체 체크해제하기
			foreach (CheckBox Chkbox in ChkBoxes)
			{
				Chkbox.IsChecked = false;
			}
		}
		public void textUpLoad()
		{
			var tex1 = _driver.FindElement(By.XPath("//*[@id='borderB']/tbody[2]/tr[1]"));
			crawlingData.Items.Add(tex1.Text);
		}

		private void button2_Initialized(object sender, EventArgs e)
		{
			_driver = new ChromeDriver(_driverService, _options);

			_driver.Navigate().GoToUrl("https://cse.jbnu.ac.kr/cse/3586/subview.do"); // 웹 사이트에 접속합니다.

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);



			var table2 = _driver.FindElementByXPath("//*[@id='menu3586_obj176']/div[2]/form[2]/table");
			var tbody2 = table2.FindElement(By.TagName("tbody"));
			var trs2 = tbody2.FindElements(By.TagName("tr"));
			foreach (var tr2 in trs2)
			{

				crawlingData.Items.Add(tr2.Text);

			}


		}

	}
}
