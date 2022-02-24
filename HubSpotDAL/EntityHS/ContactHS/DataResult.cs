using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.EntityHS.ContactHS
{
    internal class DataResult
    {
        public List<ContactData> results { get; set; }
        public string Entity { get; set; }
    }
}
