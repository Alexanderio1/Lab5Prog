namespace Abstractions
{

    public interface IController
    {
        /// <summary>
        /// Установить давление (в атмосферах) и температуру (в градусах Цельсия).
        /// </summary>
        /// <param name="pressureAtm">Давление в атмосферах</param>
        /// <param name="tempC">Температура в °C</param>
        void Set(double pressureAtm, double tempC);
    }
}
