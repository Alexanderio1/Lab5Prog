using Adapters1;
using Core1;
using System;

namespace Controller
{
    /// <summary>
    /// Этот класс реализует всю логику «диспетчера»:
    /// - спрашивает у пользователя давление (atm) и температуру (°C),
    /// - создаёт ProcessControllerAdapter (адаптер),
    /// - вызывает у него SetPressure/SetTemperature,
    /// - предлагает повторить или выйти.
    /// </summary>
    public class ProcessControlController
    {
        public void Run()
        {
            Console.WriteLine("=== Process Control Dispatcher ===");
            while (true)
            {
                double pressureAtm = PromptPressureAtm();
                double tempC = PromptTemperatureC();

                IProcessController controller = new ProcessControllerAdapter();
                controller.SetPressure(pressureAtm);
                controller.SetTemperature(tempC);

                Console.WriteLine("==================================");

                if (!AskRetry())
                {
                    Console.WriteLine("Выход из диспетчера. До свидания!");
                    break;
                }
                Console.WriteLine();
            }
        }

        private double PromptPressureAtm()
        {
            while (true)
            {
                Console.Write("Введите давление (в atm, > 0): ");
                string input = Console.ReadLine();
                if (double.TryParse(input.Replace(',', '.'), out double val) && val > 0)
                    return val;
                Console.WriteLine("Некорректное значение. Повторите.\n");
            }
        }

        private double PromptTemperatureC()
        {
            while (true)
            {
                Console.Write("Введите температуру (в °C): ");
                string input = Console.ReadLine();
                if (double.TryParse(input.Replace(',', '.'), out double val))
                    return val;
                Console.WriteLine("Некорректное значение. Повторите.\n");
            }
        }

        private bool AskRetry()
        {
            while (true)
            {
                Console.Write("Задать новые параметры? (Y/N): ");
                string answer = Console.ReadLine()?.Trim().ToUpper();
                if (answer == "Y") return true;
                if (answer == "N") return false;
                Console.WriteLine("Введите Y или N.");
            }
        }
    }
}
