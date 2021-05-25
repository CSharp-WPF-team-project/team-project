using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.Converter
{   
    public class HumidityToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int humidityValue = (int)value;
            if(humidityValue < 30)
            {
                return "습도: 낮다";
            }
            if(humidityValue < 40)
            {
                return "습도: 보통";
            }
            return "습도 : 높음";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
