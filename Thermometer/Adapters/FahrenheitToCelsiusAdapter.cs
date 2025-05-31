using FahrenheitLib;
using Thermometer.Abstractions;

namespace Thermometer.Adapters;

public class FahrenheitToCelsiusAdapter : ITemperatureConverter
{
    public double ToCelsius(double f) => FahrenheitConverter.FahrenheitToCelsius(f);
}
