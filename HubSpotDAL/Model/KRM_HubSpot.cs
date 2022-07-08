using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Model
{
    internal class KRM_HubSpot
    {
        public string IdHubspot { get; set; }
        public string cNombre { get; set; }
        public string cApellidoPaterno { get; set; }
        public string cApellidoMaterno { get; set; }
        public string dtFechaNacimiento { get; set; }
        public string cEstado { get; set; }
        public string cCP { get; set; }
        public string cCURP { get; set; }
        public string cRFC { get; set; }
        public string cNSS { get; set; }
        public string fkIdGenero { get; set; }
        public string cTelefono { get; set; }
        public string cTelefonoMovil { get; set; }
        public string cEmail { get; set; }
        public string bActivo { get; set; }
        public string fkIdPuntoProspeccion { get; set; }
        public string nMontoCreditoex { get; set; }
        public string fkIdTipoPersona { get; set; }
        public string fkIdCampaniaPublicidadRegion { get; set; }
        public string fkIdMedioPubicidad { get; set; }
        public string fkIdCampaniaPublicidad { get; set; }
        public string fkIdCampania { get; set; }
        public string dtFechaRegistro { get; set; }
        public string Recomendado_Nombre { get; set; }
        public string Recomendado_ApPaterno { get; set; }
        public string Recomendado_ApMaterno { get; set; }
        public string Recomendado_Telefono { get; set; }
        public string Recomendado_email { get; set; }
        public string fkEstadoCivil { get; set; }
        public string tipo_credito { get; set; }
        public string IdCliente { get; set; }
        public string IdHubSpot { get; set; }
        public string FechaApartado { get; set; }
        public string bitCita { get; set; }
        public string FechaCita { get; set; }
    }
}
