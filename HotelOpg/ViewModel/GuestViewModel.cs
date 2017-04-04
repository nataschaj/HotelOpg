using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;
using HotelOpg.Model;
using HotelOpg.Persistency;
using System.ComponentModel;
using System.Windows.Input;
using HotelOpg.Handler;

namespace HotelOpg.ViewModel
{
    public class GuestViewModel : INotifyPropertyChanged
    {
        private Model.Guest selectedGuest;

        public event PropertyChangedEventHandler PropertyChanged;

        public Model.GuestSingelton SingletonRef { get; set; }

        internal static void AddGuest(Guest newGuest)
        {
            throw new NotImplementedException();
        }

        public int Guest_No { get; set; }

        internal static void RemoveGuest(Guest gv)
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public ICommand CreateGuestCommand { get; set; }
        public RelayCommand DeleteGuestCommand { get; set; }
        private MyGuestHandler Guesthandler { get; set; }

        public Model.Guest SelectedGuest
        {
            get { return selectedGuest; }
            set
            {
                selectedGuest = value;
                OnPropertyChanged(nameof(SelectedGuest));
            }
        }
        public GuestViewModel()
        {
            SingletonRef = GuestSingelton.Instance;
            Guesthandler = new MyGuestHandler(this);

            CreateGuestCommand = new RelayCommand(Guesthandler.CreateGuest);
            PersistencyGuest.HentDataTilDiskAsync();
            DeleteGuestCommand = new RelayCommand(DeleteSelected, IsListEmptyCheck);
        }
        public void DeleteSelected()
        {
            Guesthandler.DeleteGuest(SelectedGuest);
        }
        protected virtual void OnPropertyChanged(string PropertyName)
        {
           if (PropertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        public bool IsListEmptyCheck()
        {
            if (SingletonRef.GuestList.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
