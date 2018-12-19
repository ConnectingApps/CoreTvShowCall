using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTvShowCall.ExternalModels
{
    public class Character
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Image3 image { get; set; }
        public Links3 _links { get; set; }
    }
}
