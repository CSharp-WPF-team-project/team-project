using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//Selenium 
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using Notice.Model;
using System.Threading;
using System.Diagnostics;

namespace Notice.ViewModel.Command.NoticeCommand
{
	/// <summary>
	/// 공지사항
	/// </summary>
    public class LmsData3Command : ICommand
	{
		int countBtn4 = 0; // 처음 실행이 아님을 확인
		 
		protected ChromeDriverService _driverService = null;
		protected ChromeOptions _options = null;
		protected ChromeDriver _driver = null;


		public event EventHandler CanExecuteChanged;

		public ViewModel VM { get; set; }
		public LmsData3Command(ViewModel vm)
		{
			VM = vm;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

			if (countBtn4 != 0)
			{
				VM.L_Data3_Main.Clear();
				VM.L_Data3.Clear();
			}
			VM.L_Data3.Add(new LmsData3()
			{
				LmsTitle3 = "데이터 로딩중"
			});
			VM.get3();
			VM.L_Data3.Clear();
			Start4();
			countBtn4++;
		}
		private async void Start4()
		{
			var task4 = Task.Run(() => NoticeCrawling());
			await task4;
			VM.get3();

		}

		public void NoticeCrawling()
		{
			_driverService = ChromeDriverService.CreateDefaultService();
			_driverService.HideCommandPromptWindow = true;
			_options = new ChromeOptions();
			_options.AddArgument("headless");
			_options.AddArgument("disable-gpu");
			_driver = new ChromeDriver(_driverService, _options);

			_driver.Navigate().GoToUrl("https://ieilms.jbnu.ac.kr/"); // 웹 사이트에 접속합니다.

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			IWebElement element;
			try
			{
				element = _driver.FindElementByXPath("//*[@id='id']");
				element.SendKeys(VM.mainWindowIDInformation.LoginID);

				element = _driver.FindElementByXPath("//*[@id='passwd']");
				element.SendKeys(VM.mainWindowIDInformation.LoginPasswd);

				element = _driver.FindElementByXPath("//*[@id='loginform']/table/tbody/tr[1]/td[2]/input");
				element.Click();

				element = _driver.FindElementByXPath("//*[@id='boardAbox']/form/table/tbody/tr[1]/td[2]");
				element.Click();
			}
			catch (Exception)
			{
				MessageBox.Show("ID,PW를 확인해주세요.");
				return;
			}

			element = _driver.FindElementByXPath("//*[@id='nav']/li[10]/a");
			element.Click();
            try
            {
				for (int i=2; i< _driver.FindElements(By.XPath("//*[@id='treebox']/div/table/tbody/tr")).Count; i++)
                {
					string BASE_Path = "//*[@id='treebox']/div/table/tbody/tr[{0}]/td[2]/table/tbody/tr/td[4]/span";
					string url = string.Format(BASE_Path, i);
					string BASE_value = url;
					element = _driver.FindElementByXPath(BASE_value);
					element.Click();
					Thread.Sleep(300);
					TextUpLoad4();
				}
			}catch(Exception ex)
            {
				return;
            }
			_driver.Close();
		}

		public void TextUpLoad4()
		{

			if (_driver.FindElementByXPath("//*[@id='board']/tbody/tr[2]").Text == "2021-1학기 " + _driver.FindElementByXPath("//*[@id='gname']").Text.Substring(9) + "강의에게 공지할 내용이 없습니다.")
			{
				VM.L_Data3.Add(new LmsData3()
				{
					LmsSubject3 = _driver.FindElementByXPath("//*[@id='gname']").Text.Substring(9),
					LmsTitle3 = "업로드된 공지가 없습니다."
				});
			}
			else
			{
				VM.L_Data3.Add(new LmsData3()
				{
					LmsSubject3 = _driver.FindElementByXPath("//*[@id='gname']").Text.Substring(9),
					LmsTitle3 = _driver.FindElementByXPath("//*[@id='board']/tbody/tr[2]/td[2]").Text,
					LmsRdate3 = _driver.FindElementByXPath("//*[@id='board']/tbody/tr[2]/td[3]").Text,

				});
			}
		}
	}
}
