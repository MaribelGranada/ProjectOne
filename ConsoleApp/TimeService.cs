using System;
using System.Globalization;
using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    public static class TimeService
    {
        // Imprime la información exactamente en el formato esperado
        public static void PrintTimeInfo(Time t, Time sumWith, Time compareWith)
        {
            // Línea de tiempo
            Console.WriteLine($"Time: {t}");

            // Números con separador de miles y alineados a la derecha (igual que el ejemplo)
            string ms = t.ToMilliseconds().ToString("N0", CultureInfo.InvariantCulture);
            string sec = t.ToSeconds().ToString("N0", CultureInfo.InvariantCulture);
            string min = t.ToMinutes().ToString("N0", CultureInfo.InvariantCulture);

            Console.WriteLine($"    Milliseconds: {ms,15}");
            Console.WriteLine($"    Seconds     : {sec,15}");
            Console.WriteLine($"    Minutes     : {min,15}");

            // Add y Is Other day
            Console.WriteLine($"    Add         : {t.Add(sumWith)}");
            Console.WriteLine($"    Is Other day: {t.IsOtherDay(compareWith)}");

            Console.WriteLine();
        }
    }
}
