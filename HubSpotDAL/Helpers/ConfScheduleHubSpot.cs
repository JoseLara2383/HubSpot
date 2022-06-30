using HubSpotDAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Helpers
{
    internal class ConfScheduleHubSpot
    {
        public static ScheduleHubSpot ScheduleHubSpot;

        /// <summary>
        /// Obtiene la configuracion de progración de la tabla
        /// </summary>
        /// <param name="IdBoardTable"></param>
        public static void getScheduleHubSpot(Int32 IdBoardTable,  DateTime fechafin)
        {
            try
            {

                ListScheduleHubSpot ListScheduleHubSpot = new ListScheduleHubSpot();

                string ruta = Path.Combine(System.IO.Path.GetDirectoryName(
                     System.Reflection.Assembly.GetExecutingAssembly().Location), @"ScheduleHubSpotSync.json");

                //if (!File.Exists(ruta))
                //{
                //    //agregamos una tarea inicial para crear el json
                //    AddScheduleTabletoJson(IdBoardTable, ListScheduleTable, ruta, TypeSync, fechafin, fechaFiltroSpam);
                //}

                ListScheduleHubSpot = ReadScheduleTable(ruta);
                if (ListScheduleHubSpot!=null && ListScheduleHubSpot.ScheduleHubSpot != null)
                {
                    ScheduleHubSpot = ListScheduleHubSpot.ScheduleHubSpot[0];
                }
               // ScheduleHubSpot = ListScheduleHubSpot.ScheduleHubSpot.Find(item => item.IdBoardTable == IdBoardTable );

                //if (scheduleTable == null)
                //{
                //    AddScheduleTabletoJson(IdBoardTable, ListScheduleTable, ruta, TypeSync, fechafin, fechaFiltroSpam);
                //}
            }
            catch (Exception ex)
            {
                ExcepcionLog.WriteLog("getScheduleTable", ex);
                throw ex;
            }

        }

        public static void UpdateScheduleTable(Int32 IdBoardTable, DateTime Fecha)
        {
            try
            {
                ScheduleHubSpot schedulehubSpottoUpd;
                ListScheduleHubSpot ListScheduleHubSpot = new ListScheduleHubSpot();

                string ruta = Path.Combine(System.IO.Path.GetDirectoryName(
                     System.Reflection.Assembly.GetExecutingAssembly().Location), @"ScheduleHubSpotSync.json");

                ListScheduleHubSpot = ReadScheduleTable(ruta);

                //scheduleTabletoUpd = ListScheduleTable.ScheduleTables.Find(item => item.IdBoardTable == IdBoardTable && item.TypeSync == TypeSync);
                schedulehubSpottoUpd = ListScheduleHubSpot.ScheduleHubSpot[0];
                schedulehubSpottoUpd.FechaUltimaEjecucion = Fecha;

                string json = JsonConvert.SerializeObject(ListScheduleHubSpot);

                System.IO.File.WriteAllText(ruta, json);

            }
            catch (Exception ex)
            {

                ExcepcionLog.WriteLog("ActualizaScheduleTable", ex);
            }
        }

        private static ListScheduleHubSpot ReadScheduleTable(string ruta)
        {
            try
            {
                ListScheduleHubSpot ListScheduleHubSpot;
                using (StreamReader jsonStream = File.OpenText(ruta))
                {
                    var jsonTable = jsonStream.ReadToEnd();
                    ListScheduleHubSpot = JsonConvert.DeserializeObject<ListScheduleHubSpot>(jsonTable);

                }

                return ListScheduleHubSpot;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       


    }
}
