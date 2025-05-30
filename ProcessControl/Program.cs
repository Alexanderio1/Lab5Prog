// Проект AdapterLab.ProcessControl
using System;
using System.Globalization;

namespace ProcessControl
{
    /* ---------- Target ---------- */
    /// <summary>Контракт, к которому «привязан» диспетчер.</summary>
    public interface IController
    {
        void Set(double pressureAtm, double tempC);
    }

    /* ---------- Adaptee 1 ---------- */
    // «Стандартный» микроконтроллер, всё в привычных ед. изм.
    class StandardController : IController
    {
        public void Set(double pressureAtm, double tempC) =>
            Console.WriteLine($"[Standard] P={pressureAtm:0.###} atm, T={tempC:0.#} °C");
    }

    /* ---------- Adaptee 2 ---------- */
    // Микроконтроллер другого вендора (изменить нельзя)
    class VendorBController
    {
        // Требует Паскали и Фаренгейты
        public void SetParameters(double pressurePa, double tempF) =>
            Console.WriteLine($"[Vendor B] P={pressurePa:N0} Pa, T={tempF:0.#} °F");
    }

    /* ---------- Adapter ---------- */
    class VendorBAdapter : IController
    {
        private readonly VendorBController _ctrl = new();

        public void Set(double pressureAtm, double tempC)
        {
            double pressurePa = pressureAtm * 101325;   // 1 atm = 101 325 Pa
            double tempF = tempC * 9 / 5 + 32;
            _ctrl.SetParameters(pressurePa, tempF);
        }
    }

    static class Input
    {
        public static double ReadDouble(string prompt, Func<double, bool>? validator = null)
        {
            while (true)
            {
                Console.Write(prompt);
                string? txt = Console.ReadLine();
                if (double.TryParse(txt, NumberStyles.Float,
                                    CultureInfo.InvariantCulture, out double value) &&
                    (validator == null || validator(value)))
                    return value;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ошибка: введите число (десятичная точка – «.»).");
                Console.ResetColor();
            }
        }
    }

    /* ---------- Client ---------- */
    class Program
    {
        static void Main()
        {
            double atm = Input.ReadDouble("Давление (atm): ",
                                          v => v >= 0);        // неотрицательно
            double c = Input.ReadDouble("Температура (°C): ");

            Console.WriteLine("\n=== Стандартный контроллер ===");
            IController standard = new StandardController();
            standard.Set(atm, c);

            Console.WriteLine("\n=== Контроллер Vendor B через адаптер ===");
            IController vendorB = new VendorBAdapter();
            vendorB.Set(atm, c);
        }
    }
}
