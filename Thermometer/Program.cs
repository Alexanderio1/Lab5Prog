// Проект AdapterLab.Thermometer
using System;
using System.Globalization;
using FahrenheitLib;        // ─── Adaptee (чужая библиотека)

namespace Thermometer
{
    /* ---------- Target ---------- */
    interface ITemperatureConverter
    {
        double ToCelsius(double value);          // датчик ⇒ °C
    }

    /* ---------- Adapters ---------- */
    /// <summary>Датчик в °F → °C (тонкий адаптер вокруг библиотеки).</summary>
    class FahrenheitToCelsiusAdapter : ITemperatureConverter
    {
        public double ToCelsius(double f) => FahrenheitConverter.FahrenheitToCelsius(f);
    }

    /// <summary>Датчик в °Ré → °C (через промежуточный °F).</summary>
    class ReaumurToCelsiusAdapter : ITemperatureConverter
    {
        public double ToCelsius(double re)
        {
            double f = re * 2.25 + 32;           // 0 °Ré = 32 °F
            return FahrenheitConverter.FahrenheitToCelsius(f);
        }
    }

    /* ---------- Утилита ввода ---------- */
    static class Input
    {
        public static double ReadDouble(string prompt,
                                        Func<double, bool>? validator = null)
        {
            while (true)
            {
                Console.Write(prompt);
                string? txt = Console.ReadLine();
                if (double.TryParse(txt, NumberStyles.Float,
                                    CultureInfo.InvariantCulture, out double val) &&
                    (validator == null || validator(val)))
                    return val;

                Warn("Ошибка: введите число, десятичная точка «.»");
            }
        }

        public static int ReadMenu(params string[] items)
        {
            while (true)
            {
                for (int i = 0; i < items.Length; i++)
                    Console.WriteLine($"[{i + 1}] {items[i]}");
                Console.Write("Выберите пункт: ");

                if (int.TryParse(Console.ReadLine(), out int n)
                    && n >= 1 && n <= items.Length)
                {
                    return n - 1;
                }

                Warn("Неверный выбор.");
            }
        }

        private static void Warn(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }

    /* ---------- Client ---------- */
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Шкала датчика:");
            int choice = Input.ReadMenu("Фаренгейт (°F)", "Реомюр (°Ré)");

            ITemperatureConverter conv = choice switch
            {
                0 => new FahrenheitToCelsiusAdapter(),
                1 => new ReaumurToCelsiusAdapter(),
                _ => throw new InvalidOperationException()
            };

            string unit = choice == 0 ? "°F" : "°Ré";
            double val = Input.ReadDouble($"Показание термометра ({unit}): ");

            Console.WriteLine($"=> {conv.ToCelsius(val):0.##} °C");
        }
    }
}
