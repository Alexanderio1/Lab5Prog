using Thermometer.Abstractions;
using Thermometer.Adapters;
using Thermometer.Utils;

namespace Thermometer;

class Program
{
    static void Main()
    {
        Console.WriteLine("Шкала датчика:");
        int idx = Input.ReadMenu("Фаренгейт (°F)", "Реомюр (°Ré)");

        ITemperatureConverter conv = idx switch
        {
            0 => new FahrenheitToCelsiusAdapter(),
            1 => new ReaumurToCelsiusAdapter(),
            _ => throw new InvalidOperationException()
        };

        string unit = idx == 0 ? "°F" : "°Ré";
        double val = Input.ReadDouble($"Показание термометра ({unit}): ");

        Console.WriteLine($"=> {conv.ToCelsius(val):0.##} °C");
    }
}
