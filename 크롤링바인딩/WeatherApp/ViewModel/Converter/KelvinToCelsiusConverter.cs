using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.Converter
{
    class KelvinToCelsiusConverter : IValueConverter
    {
        private int tempValue2;

        public int TempValue2
        {
            get { return tempValue2; }
            set { tempValue2 = value; }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double TempValue = (double)value - 273.15;

            int TempValue2 = (int)TempValue;
            return TempValue2.ToString() + "°C";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            return 0;
        }
    }
}
