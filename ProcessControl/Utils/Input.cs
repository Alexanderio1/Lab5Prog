using System.Globalization;

namespace ProcessControl.Utils;

public static class Input
{
    public static double ReadDouble(string prompt, Func<double, bool>? validator = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string? txt = Console.ReadLine();
            if (double.TryParse(txt, NumberStyles.Float, CultureInfo.InvariantCulture, out double v) &&
                (validator == null || validator(v)))
                return v;

            Warn("Ошибка: введите число (десятичная точка «.»).");
        }
    }

    private static void Warn(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}
