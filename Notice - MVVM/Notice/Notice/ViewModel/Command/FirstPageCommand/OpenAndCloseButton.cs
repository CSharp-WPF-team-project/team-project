using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Notice.ViewModel.Command.FirstPageCommand 
{
    public class OpenAndCloseButton : ICommand
    {
        
        public ViewModel VM { get; set; }

        public OpenAndCloseButton(ViewModel vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string isOpenClose = parameter.ToString();
            if(isOpenClose == "CloseMenuButton")
            {
                Visibility = Visibility.Visible;
                CloseMenuButton.Visibility = Visibility.Collapsed;
            }
            else if (isOpenClose == "OpenMenuButton")
            {
                OpenMenuButton.Visibility = Visibility.Collapsed;
                CloseMenuButton.Visibility = Visibility.Visible;
            }
        }
    }
}
