using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.Model
{
    internal class FilterHubSpot
    {
        public List<FilterGroup> filterGroups { get; set; } = new List<FilterGroup>();
        public List<string> properties { get; set; } = new List<string>();
        public List<Sorts> sorts { get; set; } = new List<Sorts>();
        public int limit { get; set; }
        public string after { get; set; }
        
    }
}
