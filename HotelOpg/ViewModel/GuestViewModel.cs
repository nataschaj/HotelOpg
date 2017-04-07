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
using HotelOpg.Facade;
using HotelOpg.ViewModel;
using System.Collections.ObjectModel;
using Windows.UI.Popups;


namespace HotelOpg.ViewModel
{
    public class GuestViewModel : INotifyPropertyChanged
    {
        private Model.Guest selectedGuest;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get { return GuestSingelton.Instance.Name; } set { GuestSingelton.Instance.Name = value; } }
        public string Address { get; set; }
        public int Guest_No { get; set; }
        public ICommand CreateGuestCommand { get; set; } //Ikke implementeret
        public RelayCommand DeleteGuestCommand { get; set; } //Ikke implementeret
        //private MyGuestHandler Guesthandler { get; set; } //Ikke brugt
        public Model.GuestSingelton SingletonRef { get; set; }
        


        public ObservableCollection<Guest> listOfGuest
        {
            get { return GuestSingelton.Instance.GuestList; }
            set
            {
                GuestSingelton.Instance.GuestList = value;
                OnPropertyChanged(nameof(listOfGuest));
            }
        }


        public ObservableCollection<Guest> GuestList
        {
            get { return GuestSingelton.Instance.GuestList; }
            set
            {
                GuestSingelton.Instance.GuestList = value;
                OnPropertyChanged(nameof(GuestList));
            }
        }

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public GuestViewModel()
        {
            LoadGuestFromDB();
            SingletonRef = GuestSingelton.Instance;
            //Guesthandler = new MyGuestHandler(this);
            //CreateGuestCommand = new RelayCommand(Guesthandler.CreateGuest);
            //DeleteGuestCommand = new RelayCommand(DeleteSelected, IsListEmptyCheck);
        }

        public async void LoadGuestFromDB()
        {
            try
            {
                GuestFacade facade = new GuestFacade();
                GuestList = await facade.GetGuest();
            }
            catch (System.Net.Http.HttpRequestException)
            {
                var msg = new MessageDialog("Ingen forbindelse");
                msg.Commands.Add(new UICommand("Luk"));
                await msg.ShowAsync();
                LoadGuestFromDB();
            }
        }


        public Model.Guest SelectedGuest
        {
            get { return GuestSingelton.Instance.SelectedGuest; }
            set
            {
                GuestSingelton.Instance.SelectedGuest = value;
                //        Name = SelectedGuest?.Name;
                //        Address = SelectedGuest?.Address;

                //        OnPropertyChanged(nameof(SelectedGuest)); //melder fejl hvis udkommenteret ??
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

        //public void DeleteSelected()
        //{
        //    Guesthandler.DeleteGuest(SelectedGuest);
        //}






    }
}
