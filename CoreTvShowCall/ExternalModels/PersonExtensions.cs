using System;

namespace CoreTvShowCall.ExternalModels
{
    public static class PersonExtensions
    {
        public static DateTime? GetBirthDate(this Person person)
        {
            var successFullyParsed = DateTime.TryParse(person.birthday, out var result);
            if (successFullyParsed)
            {
                return result;
            }
            return null;
        }
    }
}