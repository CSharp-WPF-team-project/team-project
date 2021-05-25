using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Command;

namespace WeatherApp.ViewModel
{
    public class WeatherVM
    {
        public WeatherInformation Weather { get; set; }
        public ObservableCollection<string> Cities { get; set; }


        private string selectedCity;

        public string SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                GetWeather();
            }
        }

        public RefreshCommand RefreshCommand { get; set; }

        public WeatherVM()
        {
            Weather = new WeatherInformation();
            Cities = new ObservableCollection<string>();

            Cities.Add("London");
            Cities.Add("Paris");
            Cities.Add("Jeonju");
            Cities.Add("Seoul");

            RefreshCommand = new RefreshCommand(this);
        }

        static string lastCity; // 가장 최근 업데이트 된 도시 정보 저장
        public void GetWeather(string inputText = "") // 선택적 매개변수
        {
            if (inputText == "")
            {
                var weather = WeatherAPI.GetWeatherInformation(SelectedCity);
                Weather.Name = weather.Name;
                Weather.Main = weather.Main;
                Weather.Wind = weather.Wind;
                lastCity = SelectedCity;
            }
            else // Text값이 매개로 전달되면 그 Text값의 정보 업데이트
            {
                var weather = WeatherAPI.GetWeatherInformation(inputText);
                Weather.Name = weather.Name;
                Weather.Main = weather.Main;
                Weather.Wind = weather.Wind;
                lastCity = inputText;
            }
        }
        public void GetWeather2()
        {
            if(lastCity != null)  // 가장 최근에 정보를 얻어온 도시 값 존재
            {
                var weather = WeatherAPI.GetWeatherInformation(lastCity); // 가장 최근에 정보를 얻어온 도시 값 업데이트
                Weather.Name = weather.Name;
                Weather.Main = weather.Main;
                Weather.Wind = weather.Wind;
            }
            else // 한번도 정보를 얻어온 도시가 없을 경우
            {
                return;
            }
        }
    }
}
