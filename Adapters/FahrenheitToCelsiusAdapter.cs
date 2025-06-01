using Core;
using FahrenheitLib;

namespace Adapters
{
    /// <summary>
    /// Адаптер для перевода из Fahrenheit (°F) в Celsius (°C).
    /// </summary>
    public class FahrenheitToCelsiusAdapter : ITemperatureConverter
    {
        public double ToCelsius(double f)
        {
            // Предполагаемая сигнатура из сторонней библиотеки:
            // public static class FahrenheitConverter
            // {
            //     public static double FahrenheitToCelsius(double fValue) { ... }
            // }
            return FahrenheitConverter.FahrenheitToCelsius(f);
        }
    }
}
