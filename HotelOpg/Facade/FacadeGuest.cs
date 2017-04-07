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
    public static class GuestFacade
    {
        const string serverUrl = "http://localhost:4284/api/";
        public static string messageError = "";


        //GET
        public static async Task<ObservableCollection<Guest>> getGuest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlString = "api/Guests/";

                HttpResponseMessage response = client.GetAsync(urlString).Result;
                if (response.IsSuccessStatusCode)
                {
                    var Guest = response.Content.ReadAsAsync<Guest>().Result;

                    return Guest;

                    //ObservableCollection<Guest> guestList = await response.Content.ReadAsAsync<ObservableCollection<Guest>>();

                    //return guestList;
                }
                messageError = response.StatusCode.ToString();
                return null;

            }

        }

        //private HttpClientHandler handler;


        //public async Task<ObservableCollection<Guest>> GetAllGuests()
        //{
        //    handler = new HttpClientHandler();
        //    handler.UseDefaultCredentials = true;
        //    //true if the default credentials are used; otherwise false. will use authentication credentials from the logged on user on your pc.

        //    using (HttpClient client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();

        //        var task = client.GetAsync("Guests");

        //        HttpResponseMessage response = await task;
        //        response.EnsureSuccessStatusCode();
        //        // check for response code (if response is not 200 throw exception)
        //        ObservableCollection<Guest> guestList = await response.Content.ReadAsAsync<ObservableCollection<Guest>>();

        //        return guestList;
        //    }
        //}

    }
}