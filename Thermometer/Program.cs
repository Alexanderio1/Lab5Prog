using System;
using Core;
using Adapters;

namespace AdapterLab.Thermometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Thermometer Converter ===");

            int choice;
            while (true)
            {
                Console.WriteLine("Выберите тип датчика:");
                Console.WriteLine("  1) Fahrenheit (°F)");
                Console.WriteLine("  2) Réaumur   (°Ré)");
                Console.Write("Введите номер (1 или 2): ");

                string inputChoice = Console.ReadLine();
                if (int.TryParse(inputChoice, out choice) && (choice == 1 || choice == 2))
                {
                    break;
                }

                Console.WriteLine("Неверный ввод. Пожалуйста, введите \"1\" или \"2\".\n");
            }

            double rawValue;
            while (true)
            {
                Console.Write("Введите показание датчика (число): ");
                string inputValue = Console.ReadLine();

                if (double.TryParse(inputValue.Replace(',', '.'), out rawValue))
                {
                    break;
                }

                Console.WriteLine("Неверный формат числа. Попробуйте ещё раз.\n");
            }

            ITemperatureConverter converter = choice switch
            {
                1 => new FahrenheitToCelsiusAdapter(),
                2 => new ReaumurToCelsiusAdapter(),
                _ => throw new InvalidOperationException("Неподдерживаемый тип датчика")
            };

            double celsius = converter.ToCelsius(rawValue);
            Console.WriteLine();
            Console.WriteLine($"Результат: {celsius:N2} °C");
            Console.WriteLine("==============================");

            while (true)
            {
                Console.Write("\nЖелаете выполнить ещё одно преобразование? (Y/N): ");
                string retry = Console.ReadLine()?.Trim().ToUpper();
                if (retry == "Y")
                {
                    Console.WriteLine();
                    Main(null);
                    return;
                }
                else if (retry == "N")
                {
                    Console.WriteLine("Выход из программы. До свидания!");
                    return;
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите \"Y\" или \"N\".");
                }
            }
        }
    }
}
