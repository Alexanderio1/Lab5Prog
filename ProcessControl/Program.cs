using System;
using System.Globalization;
using Abstractions;
using Standard;
using VendorBAdapter1;

namespace ProcessControl
{
    static class Program
    {
        static void Main()
        {
            double atm = ReadDouble("Давление (atm): ", v => v >= 0);
            double c = ReadDouble("Температура (°C): ");

            Console.WriteLine("\n=== Стандартный контроллер ===");
            IController standard = new StandardController();
            standard.Set(atm, c);

            Console.WriteLine("\n=== Контроллер Vendor B через адаптер ===");
            IController vendorB = new VendorBAdapter();
            vendorB.Set(atm, c);
        }

        private static double ReadDouble(string prompt, Func<double, bool>? validator = null)
        {
            while (true)
            {
                Console.Write(prompt);
                string? txt = Console.ReadLine();
                if (double.TryParse(txt,
                                    NumberStyles.Float,
                                    CultureInfo.InvariantCulture,
                                    out double value)
                    && (validator == null || validator(value)))
                {
                    return value;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ошибка: введите число (десятичная точка – «.»).");
                Console.ResetColor();
            }
        }
    }
}
