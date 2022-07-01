using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HubSpotDAL.EntityHS.ContactHS;
using HubSpotDAL.Helpers;
using HubSpotDAL.Model;
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
            var ProspectoDAL = new DAL.ProspectosDAL();
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
                {
                    ContactDAL.InsUpdData(SettingSync.SettingHubSpot.ConexionString, contactResult);
                    if (contactResult.results!= null)
                    {
                        //Enviar datos KRM
                        ProspectoDAL.SendProspectotoKRM(SettingSync.SettingHubSpot.ConexionString, contactResult.results);
                    }
                }
                if ((after == string.Empty || after == "0") && fechafiltro != SettingSync.SettingHubSpot.FechaFiltro)
                    ConfScheduleTable.UpdateScheduleTable(1, Fecha.UtcDateTime, TypeSync.HubSpottoBD, fechafiltro);
            } while (after != string.Empty);



            //Guardar la fecha 

            return "La sincronización ha terminado con éxito";

        }
        public static async Task<string> UpdContact()
        {
            SettingSync.getSetting();

            //string FechaInicioHubSpot = SettingSync.SettingHubSpot.FechaInicioHubSpot;

            //Obtener Schedule
            ConfScheduleHubSpot.getScheduleHubSpot();

            string FechaFinal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //Obtener  los datos de la Api de KRM
           var prospectos= await KRMApi.GetProspectostoKRM(new ProspectoParamGetKRM() { 
                                                            Fecha_Inicial=ConfScheduleHubSpot.ScheduleHubSpot.FechaUltimaEjecucion,
                                                            Fecha_Final =FechaFinal 
                                                            });
            var ProspectoResult = JsonConvert.DeserializeObject<KRM_HubSpotResult>(prospectos);

            //Actualizar campos de hubSpot

            //Actualizar el fecha de incio para la siguiente iteración.
            ConfScheduleHubSpot.ScheduleHubSpot.FechaUltimaEjecucion = FechaFinal;
            ConfScheduleHubSpot.UpdateScheduleHubSpot();
            // ConfScheduleHubSpot.UpdateScheduleHubSpot(FechaFinal);


            ContactDataUpd contactData = new ContactDataUpd();

            contactData.properties.correo_electrnico = "veroop@yahoo.com.mx";
            contactData.properties.am_mkt = "";

            HubSpotApi.UpdContact(contactData, "2159951");


            return "La actualización ha terminado con éxito";
        }

        public static async Task<string> SendProspectostoKRM()
        {
            SettingSync.getSetting();

           Model.ListProspectos oProspectos = new Model.ListProspectos();

            Model.Prospecto Prosp = new Model.Prospecto()
            {
                IdHubspot = "8",
                Nombre = "DIEGO",
                ApellidoPaterno = "MARTINEZ",
                ApellidoMaterno = "TORRES",
                FechadeNacimiento = "1981-03-11",
                RFC = "MATD820312SQ1",
                Genero = "1",
                Telefono = "5541122211",
                TelefonoMovil = "1176445235",
                Email = "diego.martinez.T02@gmail.com",
                TipoPersona = "1",
                EstadoCivil = "1",
                Etapa = "1",
                PuntoVenta = "1",
                MedioPubicidad = "5",
                CampañaPublicidad = "4681"
            };

            oProspectos.Prospectos.Add(Prosp);

          Prosp = new Model.Prospecto()
            {
                IdHubspot = "7",
                Nombre = "IVAN",
                ApellidoPaterno = "TORRES",
                ApellidoMaterno = "GONZALES",
                FechadeNacimiento = "1981-05-11",
                RFC = "TOGI810613SQ1",
                Genero = "1",
                Telefono = "5227812241",
                TelefonoMovil = "5117245235",
                Email = "MAGI01@gmail.com",
                TipoPersona = "1",
                EstadoCivil = "1",
                Etapa = "1",
                PuntoVenta = "1",
                MedioPubicidad = "5",
                CampañaPublicidad = "4681"
            };

            oProspectos.Prospectos.Add(Prosp);

           string test =await KRMApi.SendProspectostoKRM(oProspectos);


                return "El envio ha terminado con éxito";
        }

    }
}
