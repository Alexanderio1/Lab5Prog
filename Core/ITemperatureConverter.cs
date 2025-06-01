namespace Core
{
    /// <summary>
    /// Общий интерфейс для всех адаптеров, возвращающий температуру в °C.
    /// </summary>
    public interface ITemperatureConverter
    {
        /// <summary>
        /// Преобразовать исходное значение (в единицах датчика) в градусы Цельсия.
        /// </summary>
        /// <param name="value">Показание датчика (Fahrenheit, Reaumur и т.д.)</param>
        /// <returns>Температура в °C</returns>
        double ToCelsius(double value);
    }
}
