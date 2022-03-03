using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Helpers
{
    internal class HubSpot
    {
        private static double ConvertDateTimeToTimestamp(DateTime value)
        {
            TimeSpan epoch = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            //return the total seconds (which is a UNIX timestamp)
            return (double)epoch.TotalSeconds;
        }
        private static double ConvertDateTimeToTimestamp(string value)
        {
            TimeSpan epoch = (Convert.ToDateTime( value) - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            //return the total seconds (which is a UNIX timestamp)
            return (double)epoch.TotalSeconds;
        }

    }
}
