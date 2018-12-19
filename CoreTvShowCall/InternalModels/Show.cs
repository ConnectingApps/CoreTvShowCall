using System.Collections.Generic;

namespace CoreTvShowCall.InternalModels
{
    public class Show
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<OurCast> Persons { get; set; }
    }
}