using FahrenheitLib;
using Thermometer.Abstractions;

namespace Thermometer.Adapters;

public class ReaumurToCelsiusAdapter : ITemperatureConverter
{
    public double ToCelsius(double re)
    {
        double f = re * 2.25 + 32; // 0 °Ré = 32 °F
        return FahrenheitConverter.FahrenheitToCelsius(f);
    }
}
