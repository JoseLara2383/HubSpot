using System;
using System.Collections.Generic;
using System.Text;
using static HubSpotDAL.Helpers.EnumHubspot;

namespace HubSpotDAL.Model
{

    public class ScheduleTable
    {
        public Int32 IdBoardTable { get; set; }
        public DateTime FechaInicio { get; set; }
        public string FechaInicioSpam { get; set; }
        /// <summary>
        /// Indica si el ejecuta la sincronizacion
        /// </summary>
        public Boolean IsExecute { get; set; } = false;

        public TypeSync TypeSync { get; set; }
    }
}
