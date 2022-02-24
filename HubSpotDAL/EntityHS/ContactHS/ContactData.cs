using HubSpotDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.EntityHS.ContactHS
{
    internal class ContactData
    {
        public string id { get; set; }
        public contact properties { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public Boolean archived { get; set; }

    }
}
