namespace ProcessControl.Controllers;

/// <summary>Контроллер стороннего производителя. Требует Pa + °F.</summary>
public class VendorBController
{
    public void SetParameters(double pressurePa, double tempF) =>
        Console.WriteLine($"[Vendor B] P={pressurePa:N0} Pa, T={tempF:0.#} °F");
}
