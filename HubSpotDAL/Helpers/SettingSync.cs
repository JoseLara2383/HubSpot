
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

        internal static string GetGenero(string? _Genero)
        {
            string GeneroId = "0";
            if (!string.IsNullOrEmpty(_Genero))
            {
                var Genero = HubSpotDAL.Helpers.SettingSync.SettingHubSpot.Genero.Where(e => e.Descripcion == _Genero).ToList();
                GeneroId = Genero != null && Genero.Count > 0 ? Genero[0].ID.ToString() : "0";
            }

            return GeneroId;
        }

        internal static string GetTipoPersona(string _TipoPersona)
        {
            string TipoPersonaId = "0";
            if (!string.IsNullOrEmpty(_TipoPersona))
            {
                var TipoPersona = HubSpotDAL.Helpers.SettingSync.SettingHubSpot.TipoPersona.Where(e => e.Descripcion == _TipoPersona).ToList();
                TipoPersonaId = TipoPersona != null && TipoPersona.Count > 0 ? TipoPersona[0].ID.ToString() : "0";
            }

            return TipoPersonaId;
        }

        internal static string GetEstadoCivil(string _EstadoCivil)
        {
            string EstadoCivilId = "0";
            if (!string.IsNullOrEmpty(_EstadoCivil))
            {
                var EstadoCivil = HubSpotDAL.Helpers.SettingSync.SettingHubSpot.EstadoCivil.Where(e => e.Descripcion == _EstadoCivil).ToList();
                EstadoCivilId = EstadoCivil != null && EstadoCivil.Count > 0 ? EstadoCivil[0].ID.ToString() : "0";
            }

            return EstadoCivilId;
        }

        internal static string GetCampaniaPublicidad(string _CampaniaPublicidad)
        {
            string CampaniaPublicidadoId = "0";
            if (!string.IsNullOrEmpty(_CampaniaPublicidad))
            {
                var CampaniaPublicidad = HubSpotDAL.Helpers.SettingSync.SettingHubSpot.CampaniaPublicidad.Where(e => e.Descripcion == _CampaniaPublicidad).ToList();
                CampaniaPublicidadoId = _CampaniaPublicidad != null && CampaniaPublicidad.Count > 0 ? CampaniaPublicidad[0].ID.ToString() : "0";
            }

            return CampaniaPublicidadoId;
        }

        internal static string GetMedioPublicidad(string _MedioPublicidad)
        {
            string MedioPublicidadId = "0";
            if (!string.IsNullOrEmpty(_MedioPublicidad))
            {
                var MedioPublicidad = HubSpotDAL.Helpers.SettingSync.SettingHubSpot.MedioPublicidad.Where(e => e.Descripcion == _MedioPublicidad).ToList();
                MedioPublicidadId = MedioPublicidad != null && MedioPublicidad.Count > 0 ? MedioPublicidad[0].ID.ToString() : "0";
            }

            return MedioPublicidadId;
        }
        internal static string GetPuntoVenta(string _PuntoVenta)
        {
            string PuntoVentaId = "0";
            if (!string.IsNullOrEmpty(_PuntoVenta))
            {
                var PuntoVenta = HubSpotDAL.Helpers.SettingSync.SettingHubSpot.PuntoVenta.Where(e => e.Descripcion == _PuntoVenta).ToList();
                PuntoVentaId = PuntoVenta != null && PuntoVenta.Count > 0 ? PuntoVenta[0].ID.ToString() : "0";
            }

            return PuntoVentaId;
        }
    }
}
