using System.Globalization;

namespace Thermometer.Utils;

public static class Input
{
    public static double ReadDouble(string prompt,
                                    Func<double, bool>? validator = null)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(),
                                NumberStyles.Float,
                                CultureInfo.InvariantCulture,
                                out double v) &&
                (validator == null || validator(v)))
                return v;

            Warn("Ошибка: введите число, десятичная точка «.»");
        }
    }

    public static int ReadMenu(params string[] items)
    {
        while (true)
        {
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine($"[{i + 1}] {items[i]}");
            Console.Write("Выберите: ");

            if (int.TryParse(Console.ReadLine(), out int n) &&
                n >= 1 && n <= items.Length)
                return n - 1;

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
