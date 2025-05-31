namespace Thermometer.Abstractions;

public interface ITemperatureConverter
{
    double ToCelsius(double value);
}
