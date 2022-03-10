
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HubSpotDAL.Model;
using System.Reflection;
using System.Linq;
using System.ComponentModel;
using static HubSpotDAL.Helpers.EnumHubspot;
using HubSpotDAL.Helpers;

namespace HubSpotDAL.Helpers
{
    static class ConfScheduleTable
    {
        public static ScheduleTable scheduleTable;

        /// <summary>
        /// Obtiene la configuracion de progración de la tabla
        /// </summary>
        /// <param name="IdBoardTable"></param>
        public static void getScheduleTable(Int32 IdBoardTable, TypeSync TypeSync, DateTime fechafin,string fechaFiltroSpam)
        {
            try
            {

                ListScheduleTable ListScheduleTable = new ListScheduleTable();

                string ruta = Path.Combine(System.IO.Path.GetDirectoryName(
                     System.Reflection.Assembly.GetExecutingAssembly().Location), @"ScheduleTablesSync.json");

                if (!File.Exists(ruta))
                {
                    //agregamos una tarea inicial para crear el json
                    AddScheduleTabletoJson(IdBoardTable, ListScheduleTable, ruta, TypeSync, fechafin, fechaFiltroSpam);
                }

                ListScheduleTable = ReadScheduleTable(ruta);

                scheduleTable = ListScheduleTable.ScheduleTables.Find(item => item.IdBoardTable == IdBoardTable && item.TypeSync == TypeSync);

                if (scheduleTable == null)
                {
                    AddScheduleTabletoJson(IdBoardTable, ListScheduleTable, ruta, TypeSync, fechafin, fechaFiltroSpam);
                }
            }
            catch (Exception ex)
            {
                ExcepcionLog.WriteLog("getScheduleTable", ex);
                throw ex;
            }

        }

        private static void AddScheduleTabletoJson(int IdBoardTable, ListScheduleTable ListScheduleTable, string ruta, TypeSync TypeSync, DateTime fechaFin, string fechaFiltroSpam)
        {
            try
            {
                scheduleTable = new ScheduleTable();
                scheduleTable.IdBoardTable = IdBoardTable;
                scheduleTable.TypeSync = TypeSync;
                scheduleTable.FechaInicioSpam = fechaFiltroSpam;
                scheduleTable.FechaInicio = Convert.ToDateTime(fechaFin.ToString("yyyy/MM/dd hh:mm tt"));
                if (ListScheduleTable.ScheduleTables == null)
                    ListScheduleTable.ScheduleTables = new List<ScheduleTable>();
                ListScheduleTable.ScheduleTables.Add(scheduleTable);

                string json = JsonConvert.SerializeObject(ListScheduleTable);

                System.IO.File.WriteAllText(ruta, json);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private static ListScheduleTable ReadScheduleTable(string ruta)
        {
            try
            {
                ListScheduleTable ListScheduleTable;
                using (StreamReader jsonStream = File.OpenText(ruta))
                {
                    var jsonTable = jsonStream.ReadToEnd();
                    ListScheduleTable = JsonConvert.DeserializeObject<ListScheduleTable>(jsonTable);

                }

                return ListScheduleTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Actualiza la configuración del boardtable con la fecha.
        /// </summary>
        /// <param name="IdBoardTable"></param>
        /// <param name="Fecha"></param>
        public static void UpdateScheduleTable(Int32 IdBoardTable, DateTime Fecha, TypeSync TypeSync, string fechaFiltroSpam)
        {
            try
            {
                ScheduleTable scheduleTabletoUpd;
                ListScheduleTable ListScheduleTable = new ListScheduleTable();

                string ruta = Path.Combine(System.IO.Path.GetDirectoryName(
                     System.Reflection.Assembly.GetExecutingAssembly().Location), @"ScheduleTablesSync.json");

                ListScheduleTable = ReadScheduleTable(ruta);

                scheduleTabletoUpd = ListScheduleTable.ScheduleTables.Find(item => item.IdBoardTable == IdBoardTable && item.TypeSync== TypeSync);
                scheduleTabletoUpd.FechaInicio = Fecha;
                scheduleTabletoUpd.FechaInicioSpam= fechaFiltroSpam;
                scheduleTabletoUpd.TypeSync = TypeSync;
                string json = JsonConvert.SerializeObject(ListScheduleTable);

                System.IO.File.WriteAllText(ruta, json);

            }
            catch (Exception ex)
            {

                ExcepcionLog.WriteLog("ActualizaScheduleTable", ex);
            }
        }

        

        private static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T); if (!type.IsEnum) throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                .SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a })
                .Where(a => ((DescriptionAttribute)a.Att).Description == description).SingleOrDefault();
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

       


    }
}
