using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HotelOpg.Model;
using System.Collections.ObjectModel;
using Windows.UI.Notifications;

namespace HotelOpg.Facade
{
    public class GuestFacade
    {
        const string serverUrl = "http://localhost:9271/api/"; 
        private HttpClientHandler handler;
        public static string messageError = "";


        //GET
        //Gider ikke virker, ved ikke hvorfor
        //public static async Task<ObservableCollection<Guest>> getGuest()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(serverUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        string urlString = "api/Guests/";
        //        var task = client.GetAsync("Guests");

        //        HttpResponseMessage response = client.GetAsync(urlString).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            //var Guest = response.Content.ReadAsAsync<Guest>().Result;

        //            //return Guest;

        //            ObservableCollection<Guest> guestList = await response.Content.ReadAsAsync<ObservableCollection<Guest>>();

        //            return guestList;
        //        }
        //        messageError = response.StatusCode.ToString();
        //        return null;

        //    }

        //}


        public async Task<ObservableCollection<Guest>> GetGuest()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            
            using (HttpClient client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Guests/";
                var task = client.GetAsync("Guests");

                HttpResponseMessage response = await task;
                response.EnsureSuccessStatusCode();
                ObservableCollection<Guest> guestList = await response.Content.ReadAsAsync<ObservableCollection<Guest>>();

                return guestList;
            }
        }

    }
}