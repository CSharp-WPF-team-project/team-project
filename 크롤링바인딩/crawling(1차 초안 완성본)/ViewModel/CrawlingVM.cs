using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crawling.Model;
using crawling.ViewModel.Command;
//Selenium Library
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


/// <summary>
/// 제출일시 추가한 내역들까지 옮겨야 함.
/// </summary>

namespace crawling.ViewModel
{
    class CrawlingVM
    {
        static int countBtn1 = 0; // 처음 실행이 아님을 확인
        static int countBtn2 = 0; // 처음 실행이 아님을 확인

        public ObservableCollection<DepartmentData> D_Data { get; set; }
        public ObservableCollection<LmsData> L_Data { get; set; }

        public LoginLmsCmd LoginLmsCmd { get; set; }
        public LoginModel LoginModel { get; set; }
        public DepartmentData DepartmentData { get; set; }


        public CrawlingVM()
        {
            
            DepartmentData = new DepartmentData();

            LoginModel = new LoginModel();
            LoginLmsCmd = new LoginLmsCmd(this);


        }
    }
}
