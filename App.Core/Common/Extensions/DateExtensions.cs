using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Common.Extensions
{
    public static class DateExtensions
    {   
        /// <summary>
        /// Format Date Time
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public static string ToCustomDateFormat(this DateTime date, string dateFormat) => date.ToString(dateFormat);
        /// <summary>
        /// Converts Date Time Month Name
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToMonthString(this DateTime date) => date.ToString("MMMM");
        /// <summary>
        /// Converts Date Time to Month Number
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int ToMonth(this DateTime date) => date.Month;
        /// <summary>
        /// Converts Date Time to Year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int ToYear(this DateTime date) => date.Year;
        /// <summary>
        /// Converts Date Time to Day Name
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToDayName(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;

            return dayOfWeek.ToString();
        }
        /// <summary>
        /// Date Time First day of the month
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToFirstDayOfMonth(this DateTime value) => new DateTime(value.Year, value.Month, 1);
        /// <summary>
        /// Date Time Last day of the month
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToLastDayOfMonth(this DateTime value) => new DateTime(value.Year, value.Month, value.DaysInMonth());
        /// <summary>
        /// Date Time Days in a month
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime value) => DateTime.DaysInMonth(value.Year, value.Month);
        
       
        
    }
}
