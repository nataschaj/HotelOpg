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
           //GuestList.Add(new Guest(101, "Hamder", "EtSted 2323"));
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

       

        //public string GetJson()
        //{
        //    string json = JsonConvert.SerializeObject(GuestList);
        //    return json;
        //}



        //public void InsertJson(string jsonText)
        //{
        //    List<Guest> newList = JsonConvert.DeserializeObject<List<Guest>>(jsonText);

        //    foreach (var eventItem in newList)
        //    {
        //        GuestList.Add(eventItem);
        //    }
        //}


        //public void AddGuest(Guest newGuest)
        //{
        //    GuestList.Add(newGuest);
        //}

        //public void RemoveGuest(Guest gv)
        //{
        //    GuestList.Remove(gv);
        //}

        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
