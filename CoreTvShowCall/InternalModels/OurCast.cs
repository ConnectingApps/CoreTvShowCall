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
                //redundant but can be needed for external libraries
            }
        }
    }
}