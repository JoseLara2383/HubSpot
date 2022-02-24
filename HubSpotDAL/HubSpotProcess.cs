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

            var dataContact= await HubSpotApi.PostContact();

            var contactResult = JsonConvert.DeserializeObject<EntityHS.ContactHS.DataResult>(dataContact);

            var a = new DAL.ContactDAL();

            if(contactResult!=null)
                a.InsUpdData(SettingSync.SettingHubSpot.ConexionString, contactResult);

            return dataContact;

        }
    }
}
