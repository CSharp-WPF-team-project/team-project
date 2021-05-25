using Notice.Classes;
using Notice.ViewModel.Command;
using Notice.ViewModel.Command.HomePageCommand;
using Notice.ViewModel.Command.LoginPageCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice.ViewModel
{
    public class ViewModel
    {
        public List<DepartmentData> D_Data { get; set; }
        public exitButtonCommand exitButtonCommand { get; set; }
        public signinButtonCommand loginButtonCommand { get; set; }

        public DepartmentDataButtonCommand departmentDataButtonCommand { get; set; }

        public ViewModel()
        {

            D_Data = new List<DepartmentData>();

            exitButtonCommand = new exitButtonCommand();
            loginButtonCommand = new signinButtonCommand();
            departmentDataButtonCommand = new DepartmentDataButtonCommand(this);



        }


    }
}
