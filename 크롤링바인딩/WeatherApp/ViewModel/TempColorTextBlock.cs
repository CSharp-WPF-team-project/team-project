using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WeatherApp.ViewModel
{
    class TempColorTextBlock : TextBlock
    {

        public string TempProperty
        {
            get { return (string)GetValue(TempPropertyProperty); }
            set { SetValue(TempPropertyProperty, value); }
        }

        public static readonly DependencyProperty TempPropertyProperty =
            DependencyProperty.Register("TempProperty", typeof(string), typeof(TempColorTextBlock), new PropertyMetadata("", OnForegoundChanged));


        private static void OnForegoundChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TempColorTextBlock mytemp = source as TempColorTextBlock;

            string str=  mytemp.TempProperty.Substring(0, mytemp.TempProperty.LastIndexOf('°'));
            
            if(int.Parse(str) >= 20)
            {
                mytemp.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                mytemp.Foreground = System.Windows.Media.Brushes.Blue;
            }
        }


    }
}
