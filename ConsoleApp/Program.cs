using System;
using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Time t1 = new Time(0, 0, 0, 0);           // 00:00:00.000
                Time t2 = new Time(14, 0, 0, 0);          // 14:00:00.000 
                Time t3 = new Time(9, 34, 0, 0);          // 09:34:00.000 
                Time t4 = new Time(19, 45, 56, 0);        // 19:45:56.000 
                Time t5 = new Time(23, 3, 45, 678);       // 23:03:45.678

                Time[] times = { t1, t2, t3, t4, t5 };

                
                foreach (var t in times)
                {
                    TimeService.PrintTimeInfo(t, t3, t4);
                }

                
                try
                {
                    Time bad = new Time(45, 0, 0, 0);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex);
            }
        }
    }
}
