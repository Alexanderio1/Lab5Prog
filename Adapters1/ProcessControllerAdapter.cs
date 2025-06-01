using Core1;
using System;

namespace Adapters1
{

    public class ProcessControllerAdapter : IProcessController
    {
        public void SetPressure(double pressureInAtm)
        {
            // Конвертация из атм → Па
            double pressureInPa = pressureInAtm * 101_325.0;

            Console.WriteLine($"[Адаптер→Оборудование] Установить давление: {pressureInPa:N2} Па");
        }

        public void SetTemperature(double tempInCelsius)
        {
            // Конвертация из °C → °F
            double tempInF = tempInCelsius * 9.0 / 5.0 + 32.0;

            Console.WriteLine($"[Адаптер→Оборудование] Установить температуру: {tempInF:N2} °F");
        }
    }
}
