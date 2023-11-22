using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace SAPWeb.Utility
{
    public class CommonAttributes
    {
        public static DateTime GetDate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = DateTime.Now.ToString("dd/MM/yyyy");
            }
            string[] validDateFormats =
                       {
                  @"d/M/yyyy", @"d/MM/yyyy",
                  @"dd/M/yyyy", @"dd/MM/yyyy",
                  @"d-M-yyyy", @"d-MM-yyyy",
                  @"dd-M-yyyy", @"dd-MM-yyyy",
                  @"d.MM.yyyy", @"d.MM.yyyy",
                  @"dd.M.yyyy", @"dd.MM.yyyy",
                  @"yyyy-MM-dd",@"yyyy/MM/dd",
                  @"d/M/yyyy hh:mm:ss", @"d/MM/yyyy hh:mm:ss",
                  @"dd/M/yyyy hh:mm:ss", @"dd/MM/yyyy hh:mm:ss",
                  @"d-M-yyyy hh:mm:ss", @"d-MM-yyyy hh:mm:ss",
                  @"dd-M-yyyy hh:mm:ss", @"dd-MM-yyyy hh:mm:ss",
                  @"d.MM.yyyy hh:mm:ss", @"d.MM.yyyy hh:mm:ss",
                  @"dd.M.yyyy hh:mm:ss", @"dd.MM.yyyy hh:mm:ss",
                  @"yyyy-MM-dd hh:mm:ss",@"yyyy/MM/dd hh:mm:ss",
                  @"d/M/yyyy hh:mm:ss tt", @"d/MM/yyyy hh:mm:ss tt",
                  @"dd/M/yyyy hh:mm:ss tt", @"dd/MM/yyyy hh:mm:ss tt",
                  @"d-M-yyyy hh:mm:ss tt", @"d-MM-yyyy hh:mm:ss tt",
                  @"dd-M-yyyy hh:mm:ss tt", @"dd-MM-yyyy hh:mm:ss tt",
                  @"d.MM.yyyy hh:mm:ss tt", @"d.MM.yyyy hh:mm:ss tt",
                  @"dd.M.yyyy hh:mm:ss tt", @"dd.MM.yyyy hh:mm:ss tt",
                  @"yyyy-MM-dd hh:mm:ss tt",@"yyyy/MM/dd hh:mm:ss tt",
                  @"MM/dd/yyyy hh:mm:ss", @"MM/dd/yyyy",
                  @"MM/dd/yyyy hh:mm:ss tt", @"MM/dd/yyyy",

                  };
            //ExceptionLog.WriteInfoLog("DateFormate"+value,"Helper","GetDate()");
            return DateTime.ParseExact(value, validDateFormats, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None);
            //return DateTime.ParseExact(value, validDateFormats, null);
        }
    }
}