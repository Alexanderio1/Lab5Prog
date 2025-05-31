using ProcessControl.Abstractions;
using ProcessControl.Controllers;

namespace ProcessControl.Adapters;

/// <summary>Адаптирует VendorBController к интерфейсу IController.</summary>
public class VendorBAdapter : IController
{
    private readonly VendorBController _ctrl = new();

    public void Set(double pressureAtm, double tempC)
    {
        double pressurePa = pressureAtm * 101_325;   // 1 atm = 101 325 Pa
        double tempF = tempC * 9 / 5 + 32;
        _ctrl.SetParameters(pressurePa, tempF);
    }
}
