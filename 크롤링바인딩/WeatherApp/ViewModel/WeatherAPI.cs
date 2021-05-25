using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{
    class WeatherAPI
    {
        public const string API_KEY = "7aac7b4b2ffcb8d65bceaf80af3aa6cf";
        public const string BASE_URL = "http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";

        public static WeatherInformation GetWeatherInformation(string cityName)
        {
            WeatherInformation result = new WeatherInformation();

            string url = string.Format(BASE_URL, cityName, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url);
                string json = response.Result.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<WeatherInformation>(json);
            }

            return result;
        }
    }
}
