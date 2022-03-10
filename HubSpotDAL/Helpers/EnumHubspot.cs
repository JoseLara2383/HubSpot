using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Helpers
{
    public class EnumHubspot
    {
       public enum EnumEntityHubSport
        {
            Contact,
            Marketing,
            Product,


        }
        public enum TypeSync
        {
            HubSpottoBD = 1,
            BDtoHubSpot = 2
        }

    }
}
