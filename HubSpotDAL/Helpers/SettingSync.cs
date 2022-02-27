
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HubSpotDAL.Helpers
{
    internal static class SettingSync
    {
        public static Model.Setting SettingHubSpot;
        public static void getSetting()
        {
            try
            {
                string ruta = Path.Combine(System.IO.Path.GetDirectoryName(
                     System.Reflection.Assembly.GetExecutingAssembly().Location), @"SettingSync.json");

                using (StreamReader jsonStream = File.OpenText(ruta))
                {
                    var json = jsonStream.ReadToEnd();
                    SettingHubSpot = JsonSerializer.Deserialize<Model.Setting>(json);

                }
            }
            catch (Exception ex)
            {
                Helpers.ExcepcionLog.WriteLog("getSetting", ex);
                //throw ex;
            }

        }
    }
}
