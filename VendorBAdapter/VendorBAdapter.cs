using Abstractions;
using VendorB;

namespace VendorBAdapter1
{
    /// <summary>
    /// Адаптер для VendorBController, который переводит атм→Па и °C→°F.
    /// </summary>
    public class VendorBAdapter : IController
    {
        private readonly VendorBController _inner = new VendorBController();

        public void Set(double pressureAtm, double tempC)
        {
            // 1 atm = 101 325 Па
            double pressurePa = pressureAtm * 101_325;
            // °C → °F: (°C × 9/5) + 32
            double tempF = tempC * 9 / 5 + 32;
            _inner.SetParameters(pressurePa, tempF);
        }
    }
}
