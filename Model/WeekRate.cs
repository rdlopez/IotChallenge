using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class WeekRate : Rate
    {
        private readonly Dictionary<string, string> rates = new Dictionary<string, string>
        {
            { "00:01", "25" },
            { "09:00", "25" },
            { "09:01", "15" },
            { "18:00", "15" },
            { "18:01", "20" },
            { "24:00", "20" }
        };
        public override double GetValueDay(string hour)
        {
            var hours = new string(hour.Where(c => !char.IsLetter(c)).ToArray()).Split("-");
            var initialHour = ConvertHourToInteger(hours[0]);
            var endHour = ConvertHourToInteger(hours[1]);
            var rate = rates.Rate(initialHour, endHour).Values;
            return (endHour - initialHour) * double.Parse(rate.FirstOrDefault());
        }
        private int ConvertHourToInteger(string hour) {
            var time = hour.Split(":");
            return int.Parse(time[0]);
        }
    }
}