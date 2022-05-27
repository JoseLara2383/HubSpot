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

        public Boolean isValid()
        {
            Boolean isValidRow = true ;
            if (string.IsNullOrEmpty( Nombre))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(ApellidoPaterno))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(ApellidoMaterno))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(FechadeNacimiento))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(RFC))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(Genero))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(Telefono))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(TelefonoMovil))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(Email))
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(TipoPersona) || TipoPersona == "0")
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(EstadoCivil) || EstadoCivil=="0")
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(PuntoVenta) || PuntoVenta == "0")
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(CampañaPublicidad) || CampañaPublicidad == "0")
            {
                isValidRow = false;
            }
            if (string.IsNullOrEmpty(MedioPubicidad) || MedioPubicidad == "0")
            {
                isValidRow = false;
            }
            return isValidRow;
        }

    }


}
