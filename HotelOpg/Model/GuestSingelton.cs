using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using HotelOpg.ViewModel;



namespace HotelOpg.Model
{
    public class GuestSingelton : INotifyPropertyChanged 
    {
        public ObservableCollection<Guest> GuestList { get; set; }
        private static GuestSingelton instance;
        public event PropertyChangedEventHandler PropertyChanged;
        private Guest selectedGuest;
        public string Name { get; set; }
        public string Address { get; set; }
  

        public Guest SelectedGuest
        {
            get { return selectedGuest; }
            set
            {
                selectedGuest = value;
                OnPropertyChanged(nameof(SelectedGuest));

            }
        }

        private GuestSingelton()
        {
            GuestList = new ObservableCollection<Guest>();
        }

        public static GuestSingelton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GuestSingelton();
                }
                return instance;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
