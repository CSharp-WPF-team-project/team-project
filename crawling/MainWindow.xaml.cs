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
			button2.Click += button2_Initialized;

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

			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[1]/td[2]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();
			textUpLoad();
			_driver.Navigate().Back();
			_driver.Navigate().Back();

			Thread.Sleep(50);
			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[1]/td[3]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();
			textUpLoad();
			_driver.Navigate().Back();
			_driver.Navigate().Back();

			Thread.Sleep(50);
			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[1]/td[4]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();
			textUpLoad();
			_driver.Navigate().Back();
			_driver.Navigate().Back();

			Thread.Sleep(50);
			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[2]/td[1]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();
			textUpLoad();
			_driver.Navigate().Back();
			_driver.Navigate().Back();

			Thread.Sleep(50);
			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[2]/td[2]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();
			textUpLoad();
			_driver.Navigate().Back();
			_driver.Navigate().Back();

			Thread.Sleep(50);
			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[2]/td[3]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();
			textUpLoad();
			_driver.Navigate().Back();
			_driver.Navigate().Back();

			Thread.Sleep(50);
			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[2]/td[4]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();
			textUpLoad();
			_driver.Navigate().Back();
			_driver.Navigate().Back();

			_driver.Close();
		}

		public void textUpLoad()
        {
			var element = _driver.FindElementByXPath("//*[@id='nav']/li[3]/a");
			element.Click();


			var tex1 = _driver.FindElement(By.XPath("//*[@id='borderB']/tbody[2]/tr[1]"));
			crawlingData.Items.Add(tex1.Text);
		}

			/*
			var table = _driver.FindElementByXPath("//*[@id='borderB']/tbody[2]");
			var trs = table.FindElements(By.TagName("tr"));

			foreach (var tr in trs)
			{
				var tds = tr.FindElements(By.TagName("td"));
				foreach (var td in tds)
				{
					var classN = td.FindElement(By.XPath("//*[@id='borderB']/tbody[2]/tr[1]"));
					crawlingData.Items.Add(classN.Text);
				   
			    }
			}

			/*
			element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[2]/td[1]/div/table/tbody/tr/td[2]/div[1]");
			element.Click();

			element = _driver.FindElementByXPath("//*[@id='nav']/li[3]/a");
			element.Click();

			element = _driver.FindElement(By.XPath("//*[@id='borderB']/tbody[2]/tr[1]"));
			crawlingData.Items.Add(element.Text);
			*/

			/*
			var table = _driver.FindElementByXPath("//*[@id='borderB']/tbody[2]");
			var trs = table.FindElements(By.TagName("tr"));

			foreach (var tr in trs)
			{
				var tds = tr.FindElements(By.TagName("td"));
				foreach (var td in tds)
				{
					var classN = td.FindElement(By.XPath("//*[@id='borderB']/tbody[2]/tr[1]"));
					crawlingData.Items.Add(classN.Text);
				   
			    }
			}
			*/
			//*[@id="borderB"]/tbody[2]/tr[1]/td[2]/a
			//*[@id="borderB"]/tbody[2]/tr[2]/td[2]/a
			//*[@id="borderB"]/tbody[2]/tr[9]/td[2]/a


		
		private void button2_Initialized(object sender, EventArgs e)
		{
			_driver = new ChromeDriver(_driverService, _options);

			_driver.Navigate().GoToUrl("https://cse.jbnu.ac.kr/cse/3586/subview.do"); // 웹 사이트에 접속합니다.

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);



			var table = _driver.FindElementByXPath("//*[@id='menu3586_obj176']/div[2]/form[2]/table");
			var tbody = table.FindElement(By.TagName("tbody"));
			var trs = tbody.FindElements(By.TagName("tr"));
			foreach (var tr in trs)
			{
			
						crawlingData.Items.Add(tr.Text);
					
			}
		}
	}
}


