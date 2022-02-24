using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Model
{
    internal class Filter
    {
        public string propertyName { get; set; }
        public string @operator { get; set; }
        public string value { get; set; }

    }
}
