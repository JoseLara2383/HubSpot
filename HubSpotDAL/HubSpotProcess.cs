using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HubSpotDAL.Helpers;
using HubSpotDAL.WebClient;
using Newtonsoft.Json;

namespace HubSpotDAL
{
    public class HubSpotProcess
    {

        public static async Task<string> GetContact()
        {
            SettingSync.getSetting();
            string after = "0";
            string lastDate;
            string fechafiltro = "919747892000";
            string pageAfterLimit = "10000";
            //Recorrer los contacts para procesarlos
            var ContactDAL = new DAL.ContactDAL();
            do
            {           
                var dataContact = await HubSpotApi.PostContact(fechafiltro, after);

                var contactResult = JsonConvert.DeserializeObject<EntityHS.ContactHS.DataResult>(dataContact);

                if ((contactResult != null && contactResult.paging != null && contactResult.paging.next != null && contactResult.paging.next.after != null))
                {
                    after = contactResult.paging.next.after;
                    lastDate = contactResult.results[contactResult.results.Count - 1].updatedAt;
                }
                else
                    after = string.Empty;
              
                if (contactResult != null)
                    ContactDAL.InsUpdData(SettingSync.SettingHubSpot.ConexionString, contactResult);
            } while (after!=string.Empty);

            
            return "La sincronizacion ha terminado con exito";

        }
    }
}
