// Проект AdapterLab.Clock
using System;
using System.Text.RegularExpressions;

namespace Clock
{
    /* ---------- Adaptee ---------- */
    // У часов есть только один метод – задать углы стрелок
    // (0° — вертикально вверх, по часовой стрелке).
    class AnalogClock
    {
        public void SetHands(double hourAngle, double minuteAngle) =>
            Console.WriteLine($"[AnalogClock] hour={hourAngle:0.##}°, minute={minuteAngle:0.##}°");
    }

    /* ---------- Target ---------- */
    interface IDigitalClock
    {
        void SetTime(int hours, int minutes);   // формат HH:MM
    }

    /* ---------- Adapter ---------- */
    class DigitalToAnalogAdapter : IDigitalClock
    {
        private readonly AnalogClock _clock = new();

        public void SetTime(int hours, int minutes)
        {
            hours %= 12;
            double minuteAngle = minutes * 6;           // 360° / 60
            double hourAngle = (hours + minutes / 60.0) * 30; // 360° / 12
            _clock.SetHands(hourAngle, minuteAngle);
        }
    }
    static class Input
    {
        private static readonly Regex TimeRegex = new(@"^\s*(\d{1,2})[:\.](\d{1,2})\s*$");

        public static (int h, int m) ReadTime()
        {
            while (true)
            {
                Console.Write("Введите время (HH:MM): ");
                var match = TimeRegex.Match(Console.ReadLine() ?? "");
                if (match.Success &&
                    int.TryParse(match.Groups[1].Value, out int h) &&
                    int.TryParse(match.Groups[2].Value, out int m) &&
                    h is >= 0 and < 24 &&
                    m is >= 0 and < 60)
                {
                    return (h, m);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ошибка: введите, например, 09:30 или 21.05");
                Console.ResetColor();
            }
        }
    }
    /* ---------- Client ---------- */
    class Program
    {
        static void Main()
        {
            var (h, m) = Input.ReadTime();

            IDigitalClock clock = new DigitalToAnalogAdapter();
            clock.SetTime(h, m);
        }
    }
}
