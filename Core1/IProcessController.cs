namespace Core1
{

    public interface IProcessController
    {
        /// <param name="pressureInAtm">Давление в атм.</param>
        void SetPressure(double pressureInAtm);

        /// <param name="tempInCelsius">Температура в °C.</param>
        void SetTemperature(double tempInCelsius);
    }
}
