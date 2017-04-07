using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HotelOpg.Model;
using Windows.UI.Notifications;

namespace HotelOpg.Facade
{
    public static class GuestFacade
    {
        const string serverUrl = "http://localhost:4284/";
        public static string messageError = "";


        //GET
        public static async Task<Guest> getGuest()
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
                }
                messageError = response.StatusCode.ToString();
                return null;

            }
          
        }

    }
}