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
        public ICommand CreateGuestCommand { get; set; }
        public RelayCommand DeleteGuestCommand { get; set; }
        private MyGuestHandler Guesthandler { get; set; }
        public Model.GuestSingelton SingletonRef { get; set; }
        public int Guest_No { get; set; }



        //internal static void AddGuest(Guest newGuest)
        //{
        //    throw new NotImplementedException();
        //}


        //internal static void RemoveGuest(Guest gv)
        //{
        //    throw new NotImplementedException();
        //}

        //public ObservableCollection<Guest> listOfGuest
        //{
        //    get { return GuestSingelton.Instance.GuestList; }
        //    set
        //    {
        //        GuestSingelton.Instance.GuestList = value;
        //        OnPropertyChanged(nameof(listOfGuest));
        //    }
        //}


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
            LoadDataFromDB();
            SingletonRef = GuestSingelton.Instance;
            //Guesthandler = new MyGuestHandler(this);

            //CreateGuestCommand = new RelayCommand(Guesthandler.CreateGuest);
            //PersistencyGuest.HentDataTilDiskAsync();
            //DeleteGuestCommand = new RelayCommand(DeleteSelected, IsListEmptyCheck);
        }

        public async void LoadDataFromDB()
        {
            try
            {
                GuestFacade facade = new GuestFacade();
                GuestList = await facade.GetAllGuests();
            }
            catch (System.Net.Http.HttpRequestException)
            {
                var msg = new MessageDialog("Kan ikke forbinde til webservice");
                msg.Commands.Add(new UICommand("Prøv igen"));
                await msg.ShowAsync();
                LoadDataFromDB();
            }
        }

        //public async void LoadDataFromDB()
        //{
        //    try
        //    {
        //        GuestFacade facade = new GuestFacade();
        //        GuestList = await GuestFacade.getGuest();
        //    }
        //    catch (System.Net.Http.HttpRequestException)
        //    {
        //        var msg = new MessageDialog("Kan ikke forbinde til webservice");
        //        msg.Commands.Add(new UICommand("Prøv igen"));
        //        await msg.ShowAsync();
        //        LoadDataFromDB();
        //    }
        //}

        public Model.Guest SelectedGuest
        {
            get { return GuestSingelton.Instance.SelectedGuest; }
            set
            {
                GuestSingelton.Instance.SelectedGuest = value;
                //        Name = SelectedGuest?.Name;
                //        Address = SelectedGuest?.Address;

                //        OnPropertyChanged(nameof(SelectedGuest));
            }
        }


       


        



        //public void DeleteSelected()
        //{
        //    Guesthandler.DeleteGuest(SelectedGuest);
        //}
        
        //public bool IsListEmptyCheck()
        //{
        //    if (SingletonRef.GuestList.Count < 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}


        
        
    }
}
