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
            
        }
    }
}
