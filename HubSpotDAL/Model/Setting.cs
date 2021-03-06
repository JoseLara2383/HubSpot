using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Model
{
    internal class Setting
    {
        public string ConexionString { get; set; }
        public string UrlApiHubSpot { get; set; }
        public string UrlApiKRM { get; set; }

        public string UrlApiKRMUpd { get; set; }
        public string UrlApiKRMTokenUpd { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Grant_type { get; set; }
        
        public string HubSpotId { get; set; }

        public string APiKey { get; set; }

        public Int32 NumItemsxPage { get; set; } = 100;

        public Int32 HorasSQL { get; set; } = 0;
        public string FechaFiltro { get; set; }

        public string FechaInicioHubSpot { get; set; } = "1999-01-01";
        public List<ColumnsEntity> ColumsEntity { get; set; }
        public List<PuntoVenta> PuntoVenta { get; set; }
        public List<MedioPublicidad> MedioPublicidad { get; set; }
        public List<CampaniaPublicidad> CampaniaPublicidad { get; set; }
        public List<TipoPersona> TipoPersona { get; set; }
        public List<EstadoCivil> EstadoCivil { get; set; }
        public List<Genero> Genero { get; set; }
    }
}
