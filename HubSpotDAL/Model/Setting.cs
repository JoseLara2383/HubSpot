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
   
        public string HubSpotId { get; set; }

        public string APiKey { get; set; }

        public Int32 NumItemsxPage { get; set; }

        public Int32 HorasSQL { get; set; } = 0;

        public List<ColumnsEntity> ColumsEntity { get; set; }
    }
}
