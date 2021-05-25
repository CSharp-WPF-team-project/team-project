using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Command
{
    public class RefreshCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public RefreshCommand(WeatherVM vm)
        {
            VM = vm;
        } 

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string inputText = parameter as string;
            if (inputText != null && inputText != "") // 텍스트가 비어있지 않다면
            {
                if (VM.Cities.Contains(inputText)) // 텍스트가 요소에 이미 포함돼있는 경우
                {
                    VM.GetWeather(inputText);
                }
                else //텍스트를 새롭게 요소에 포함시키는 경우
                {
                    VM.Cities.Add(inputText);
                    VM.GetWeather(inputText);
                }
            }
            else // 텍스트가 비어있는 경우
            {

                VM.GetWeather2();
            }
        }
    }
}
