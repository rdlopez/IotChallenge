using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public static class ExtensionHelper
    {
        public static Dictionary<string, string> Rate(this Dictionary<string, string> source, int initValue, int endValue)
        {

            var result = new Dictionary<string, string>();
            for (int i = 0; i < source.Count; i++)
            {
                var item = source.ElementAt(i);
                if ((i + 1) == source.Count && result.Count <= 0)
                {
                    result.Add(item.Key, item.Value);
                }
                else if(result.Count <= 0) {
                    var nextItem = source.ElementAt(i + 1);
                    if (initValue >= ConvertHourToInteger(item.Key) && endValue <= ConvertHourToInteger(nextItem.Key))
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }
            return result;
        }
        static int ConvertHourToInteger(string hour)
        {
            var time = hour.Split(":");
            return int.Parse(time[0]);
        }
    }
}
