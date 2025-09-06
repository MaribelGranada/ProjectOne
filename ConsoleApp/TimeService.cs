using System;
using System.Globalization;
using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    public static class TimeService
    {
       
        public static void PrintTimeInfo(Time t, Time sumWith, Time compareWith)
        {

            Console.WriteLine($"Time: {t}");

     
            string ms = t.ToMilliseconds().ToString("N0", CultureInfo.InvariantCulture);
            string sec = t.ToSeconds().ToString("N0", CultureInfo.InvariantCulture);
            string min = t.ToMinutes().ToString("N0", CultureInfo.InvariantCulture);

            Console.WriteLine($"    Milliseconds: {ms,15}");
            Console.WriteLine($"    Seconds     : {sec,15}");
            Console.WriteLine($"    Minutes     : {min,15}");


            Console.WriteLine($"    Add         : {t.Add(sumWith)}");
            Console.WriteLine($"    Is Other day: {t.IsOtherDay(compareWith)}");

            Console.WriteLine();
        }
    }
}
