using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Model
{
    public class Employee : IEmployee
    {
        #region Fields 

        private string regexName = @"([\S\s]+)=";
        private string regexDays = @"=([\S\s]+)";

        #endregion
        #region Properties
        public string Name { get; set; }
        public double Total { get; set; }
        #endregion
        #region Constructor
        public Employee(string employeeInfo)
        {
            var match = Regex.Match(employeeInfo, regexName);
            if (match.Success)
            {
                Name = match.Value?.Replace("=", "");
            }
            else {
                throw new Exception();
            }

            var matchDays = Regex.Match(employeeInfo, regexDays);
            if (matchDays.Success)
            {
                Total = CalculateTotal(matchDays.Value);
            }
            else
            {
                throw new Exception();
            }
        }
        #endregion
        #region Methods
        public double CalculateTotal(string days)
        {
            double total = 0;
            var request = days?.Replace("=", "").Split(",");
            foreach (var item in request)
            {
                if (item.Contains("MO") || item.Contains("TU") || item.Contains("WE") || item.Contains("TH") || item.Contains("FR"))
                {
                    WeekRate weekRate = new WeekRate();
                    var dayTotal = weekRate.GetValueDay(item);
                    total += dayTotal;
                }
                else
                {
                    WeekendRate weekendRate = new WeekendRate();
                    var dayTotal = weekendRate.GetValueDay(item);
                    total += dayTotal;
                }
            }
            return total;
        }
        #endregion
    }
}