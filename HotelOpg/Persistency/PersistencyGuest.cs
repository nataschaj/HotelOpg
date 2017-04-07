using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;
using HotelOpg.Model;

namespace HotelOpg.Persistency
{
    class PersistencyGuest
    {
        //static StorageFolder localfolder = null;
        //static private readonly string filnavn = "JsonTextEvent.json";


        //public static async void GemDataTilAsync()
        //{
        //    localfolder = ApplicationData.Current.LocalFolder;
        //    string jsonText = GuestSingelton.Instance.GetJson();
        //    StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
        //    await FileIO.WriteTextAsync(file, jsonText);

        //}



        //public static async void HentDataTilDiskAsync()
        //{
        //    try
        //    {
        //        localfolder = ApplicationData.Current.LocalFolder;
        //        StorageFile file = await localfolder.GetFileAsync(filnavn);
        //        string jsonText = await FileIO.ReadTextAsync(file);
        //        GuestSingelton.Instance.GuestList.Clear();
        //        GuestSingelton.Instance.InsertJson(jsonText);
        //    }
        //    catch (Exception)
        //    {

        //    }

        //}
    }
}
