using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawling.Model
{
    class Grade : INotifyPropertyChanged
    {
        private string grade21;
        private string grade18;
        private string grade15;
        public string Grade21
        {
            get
            {
                return grade21;
            }
            set
            {
                grade21 = value;
                OnPropertyUpdate("Grade21");
            }
        }
        public string Grade18
        {
            get
            {
                return grade18;
            }
            set
            {
                grade18 = value;
                OnPropertyUpdate("Grade18");
            }
        }
        public string Grade15
        {
            get
            {
                return grade15;
            }
            set
            {
                grade15 = value;
                OnPropertyUpdate("Grade15");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
