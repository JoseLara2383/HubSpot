using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HubSpotDAL.EntityHS.ContactHS;
using HubSpotDAL.Helpers;
using HubSpotDAL.WebClient;
using Newtonsoft.Json;
using static HubSpotDAL.Helpers.EnumHubspot;

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
            string fechafiltro = SettingSync.SettingHubSpot.FechaFiltro;//"919747892000";//23-feb-1999 23:31:23
            //ver la fecha inicial para la carga de todos los datos
            //tomar la ultima fecha para las siguientes actualizaciones
            //no modicar la fecha ultima sino trae nada de datos.
            //probar las actualizacion de un registro y seguidamente hacer el filtro.

            string pageAfterLimit = "10000";
            DateTimeOffset Fecha;
            //Recorrer los contacts para procesarlos
            var ContactDAL = new DAL.ContactDAL();
            do
            {
                //Recuperar la fecha guardar, ultima de ejecucion
                //Obtener la fecha que corrio el sync para la tabla
                Fecha = _tools.ConvertUnixTimeToDatetime(long.Parse(fechafiltro));
                ConfScheduleTable.getScheduleTable(1, TypeSync.HubSpottoBD, Fecha.UtcDateTime, fechafiltro);

                var dataContact = await HubSpotApi.PostContact(ConfScheduleTable.scheduleTable.FechaInicioSpam, after);

                var contactResult = JsonConvert.DeserializeObject<EntityHS.ContactHS.DataResult>(dataContact);

                if ((contactResult != null && contactResult.paging != null && contactResult.paging.next != null && contactResult.paging.next.after != null))
                {
                    after = contactResult.paging.next.after;
                    lastDate = contactResult.results[contactResult.results.Count - 1].updatedAt;
                    //convertir la fecha string a spam - 
                    var fechaSpan = _tools.ConvertDateUnixTime(Convert.ToDateTime(lastDate));
                    fechafiltro = fechaSpan.ToString();
                    Fecha = _tools.ConvertUnixTimeToDatetime(long.Parse(fechafiltro));

                    if (pageAfterLimit == after)
                    {

                        after = "0";
                    }
                }
                else
                {
                    after = string.Empty;
                    if (contactResult != null && contactResult.results != null)
                    {
                        lastDate = contactResult.results[contactResult.results.Count - 1].updatedAt;
                        //convertir la fecha string a spam - 
                        var fechaSpan = _tools.ConvertDateUnixTime(Convert.ToDateTime(lastDate));
                        fechafiltro = fechaSpan.ToString();
                        Fecha = _tools.ConvertUnixTimeToDatetime(long.Parse(fechafiltro));
                    }
                }


                if (contactResult != null)
                    ContactDAL.InsUpdData(SettingSync.SettingHubSpot.ConexionString, contactResult);
                if ((after == string.Empty || after == "0") && fechafiltro != SettingSync.SettingHubSpot.FechaFiltro)
                    ConfScheduleTable.UpdateScheduleTable(1, Fecha.UtcDateTime, TypeSync.HubSpottoBD, fechafiltro);
            } while (after != string.Empty);



            //Guardar la fecha 

            return "La sincronización ha terminado con éxito";

        }
        public static async Task<string> UpdContact()
        {
            SettingSync.getSetting();

            ContactDataUpd contactData = new ContactDataUpd();
                  
            contactData.properties.correo_electrnico = "veroop@yahoo.com.mx";
            contactData.properties.am_mkt = "";

            HubSpotApi.UpdContact(contactData, "2159951");


            return "La actualización ha terminado con éxito";
        }

    }
}
