using System;

namespace CoreTvShowCall.InternalModels
{
    public class OurCast
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Internal birthday values, should not be serialized by external libraries
        /// </summary>
        internal DateTime? BirthDayValue { get; set; }

        public string BirthDay
        {
            get
            {
                if (BirthDayValue == null)
                {
                    return null;
                }

                return $"{BirthDayValue.Value.Year}-{BirthDayValue.Value.Month}-{BirthDayValue.Value.Day}";
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                var values = value.Split("-");
                BirthDayValue = new DateTime(int.Parse(values[0]),int.Parse(values[1]),int.Parse(values[2]));
            }
        }
    }
}