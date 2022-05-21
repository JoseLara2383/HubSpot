using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Model
{
    internal class Prospecto
    {
        public string IdHubspot { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechadeNacimiento { get; set; }
        public string RFC { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string TelefonoMovil { get; set; }
        public string Email { get; set; }
        public string TipoPersona { get; set; }
        public string EstadoCivil { get; set; }
        public string Etapa { get; set; }
        public string PuntoVenta { get; set; }
        public string MedioPubicidad { get; set; }
        public string CampañaPublicidad { get; set; }
    }
}
