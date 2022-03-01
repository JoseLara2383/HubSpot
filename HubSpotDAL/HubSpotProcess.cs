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
            //Recorrer los contacts para procesarlos
            var ContactDAL = new DAL.ContactDAL();
            do
            {

                var dataContact = await HubSpotApi.PostContact(after);

                var contactResult = JsonConvert.DeserializeObject<EntityHS.ContactHS.DataResult>(dataContact);

                if(( contactResult.paging!=null && contactResult.paging.next!=null && contactResult.paging.next.after != null) )
                {
                    after = contactResult.paging.next.after ;
                }
                if (contactResult != null)
                    ContactDAL.InsUpdData(SettingSync.SettingHubSpot.ConexionString, contactResult);
            } while (after!=string.Empty);

            

         

            return "La sincronizacion ha terminado con exito";

        }
    }
}
