using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelOpg.Model
{
    public class Guest : INotifyPropertyChanged
    {
        public int Guest_No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Guest(/*int guest_no,*/ string name, string address)
        {
            //Guest_No = guest_no;
            Name = name;
            Address = address;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Guest_No + " " + Name + " " + Address;
        }
    }
}
