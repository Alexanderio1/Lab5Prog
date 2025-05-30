namespace FahrenheitLib
{
    public static class FahrenheitConverter
    {
        public static double FahrenheitToCelsius(double f) => (f - 32) * 5 / 9;
    }
}
