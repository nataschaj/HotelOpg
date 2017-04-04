using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace HotelOpg.Model
{
    public class GuestSingelton
    {
        public ObservableCollection<Guest> GuestList { get; set; }

        private static GuestSingelton instance;

        private GuestSingelton()
        {
            GuestList = new ObservableCollection<Guest>();
            GuestList.Add(new Guest(101, "Hamder", "EtSted 2323"));
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

        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(GuestList);
            return json;
        }
        public void InsertJson(string jsonText)
        {
            List<Guest> newList = JsonConvert.DeserializeObject<List<Guest>>(jsonText);

            foreach (var eventItem in newList)
            {
                GuestList.Add(eventItem);
            }
        }

        public void AddGuest(Guest newGuest)
        {
            GuestList.Add(newGuest);
        }

        public void RemoveGuest(Guest gv)
        {
            GuestList.Remove(gv);
        }
}
