﻿using System.ComponentModel;

namespace Notice.Model
{
    public class MainWindowIDInformation : INotifyPropertyChanged
    {
        //ID정보 저장
        private string userID;
   
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            var handle = PropertyChanged; // event delegate
            if (handle != null)
            {
                handle(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string UserID
        {
            get { return userID; }
            set { 
                userID = value;
                OnPropertyChanged("UserID");
            }
        }

    }
}
