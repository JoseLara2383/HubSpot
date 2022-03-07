using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Helpers
{
    internal class Tools
    {
        public long ConvertDateUnixTime(DateTime date)
        {
            try
            {
               return long.Parse(((DateTimeOffset)date).ToUnixTimeSeconds().ToString() + "000");
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
        public DateTimeOffset ConvertUnixTimeToDatetime(long unixTime)
        {
            try
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(unixTime);
                return dateTimeOffset;
            }
            catch (Exception)
            {
                return new DateTime(1999,1,1);
            }
            
        }
    }
}
