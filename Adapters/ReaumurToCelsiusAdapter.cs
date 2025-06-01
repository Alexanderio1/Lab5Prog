using Core;

namespace Adapters
{
    /// <summary>
    /// Адаптер для перевода из Réaumur (°Ré) → Celsius (°C)
    /// через промежуточный перевод в Fahrenheit (°F).
    /// Формула: F = Ré * 2.25 + 32
    /// </summary>
    public class ReaumurToCelsiusAdapter : ITemperatureConverter
    {
        public double ToCelsius(double re)
        {
            // Преобразуем Réaumur → Fahrenheit:
            double f = re * 2.25 + 32.0;
            // И затем переиспользуем ту же логику, что и в FahrenheitToCelsiusAdapter.
            return FahrenheitLib.FahrenheitConverter.FahrenheitToCelsius(f);
        }
    }
}
