using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Model
{
    internal class Sorts
    {
        /// <summary>
        /// Nombre del campo con el cual se va a filtrar.
        /// </summary>
       public string propertyName = "lastmodifieddate";
        /// <summary>
        /// DESCENDING-ASCENDING-ASCENDING
        /// </summary>
        public string direction = "ASCENDING";
    }
}
