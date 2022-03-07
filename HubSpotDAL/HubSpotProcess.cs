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
            Tools _tools = new Tools();
            SettingSync.getSetting();
            string after = "0";
            string lastDate;
            string fechafiltro = "919747892000";//23-feb-1999 23:31:23
            //ver la fecha inicial para la carga de todos los datos
            //tomar la ultima fecha para las siguientes actualizaciones
            //no modicar la fecha ultima sino trae nada de datos.
            //probar las actualizacion de un registro y seguidamente hacer el filtro.

            string pageAfterLimit = "10000";
            //Recorrer los contacts para procesarlos
            var ContactDAL = new DAL.ContactDAL();
            do
            {           
                //Recuperar la fecha guardar, ultima de ejecucion

                var dataContact = await HubSpotApi.PostContact(fechafiltro, after);

                var contactResult = JsonConvert.DeserializeObject<EntityHS.ContactHS.DataResult>(dataContact);

                if ((contactResult != null && contactResult.paging != null && contactResult.paging.next != null && contactResult.paging.next.after != null))
                {
                    after = contactResult.paging.next.after;
                    if(pageAfterLimit== after)
                    {
                        lastDate = contactResult.results[contactResult.results.Count - 1].updatedAt;
                        //convertir la fecha string a spam - 
                        var fechaSpan = _tools.ConvertDateUnixTime(Convert.ToDateTime(lastDate));
                        fechafiltro = fechaSpan.ToString();

                        after = "0";
                    }
                }
                else
                    after = string.Empty;
                
                //TEST UNIX
                //var unixTime =_tools .ConvertDateUnixTime(DateTime.Now);
                //var datetim = _tools.ConvertUnixTimeToDatetime(unixTime);



                if (contactResult != null)
                    ContactDAL.InsUpdData(SettingSync.SettingHubSpot.ConexionString, contactResult);
            } while (after != string.Empty);



            //Guardar la fecha 
            
            return "La sincronizacion ha terminado con exito";

        }
    }
}
