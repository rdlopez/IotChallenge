using System.Collections.Generic;
using System.Linq;

namespace Model
{
    internal class WeekendRate : Rate
    {
        private readonly Dictionary<string, string> rates = new Dictionary<string, string>
        {
            { "00:01", "30" },
            { "09:00", "30" },
            { "09:01", "20" },
            { "18:00", "20" },
            { "18:01", "25" },
            { "24:00", "25" }
        };
        public override double GetValueDay(string hour)
        {
            var hours = new string(hour.Where(c => !char.IsLetter(c)).ToArray()).Split("-");
            var initialHour = ConvertHourToInteger(hours[0]);
            var endHour = ConvertHourToInteger(hours[1]);
            var rate = rates.Rate(initialHour, endHour).Values;
            return (endHour - initialHour) * double.Parse(rate.FirstOrDefault());
        }
        private int ConvertHourToInteger(string hour)
        {
            var time = hour.Split(":");
            return int.Parse(time[0]);
        }
    }
}
