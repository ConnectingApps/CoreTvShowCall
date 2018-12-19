using System.Linq;
using CoreTvShowCall.ExternalModels;
using CoreTvShowCall.InternalModels;

namespace CoreTvShowCall
{
    public static class DataMapper
    {
        public static Show MapToExternal(RootObject root)
        {
            var result = new Show
            {
                Id = root.id,
                Name = root.name,
                Persons = root._embedded.cast.Select(c => new OurCast
                {
                    BirthDayValue = c.person.GetBirthDate(),
                    Id = c.person.id,
                    Name = c.person.name
                }).OrderByDescending(o => o.BirthDayValue).ToList()
            };
            return result;
        }
    }
}